﻿using System;
using System.Collections.Generic;
using System.IO;
using Un4seen.Bass.AddOn.Tags;
using System.Runtime.InteropServices;


namespace ArientMusicPlayer {
	public class FileManager {

		static string playlistExtension = ".arientpl";
		static string playlistSubfolder = "\\Playlists\\";

		#region External Imports
		//Loads in a Playlist file from disk
		public static ExternalPlaylist ImportPlaylistM3U8(string pathofile) {

			//await Task.Yield(); //for use with an async method.
			//Put this at top of the method to force the whole thing to be an async method.
			//usage is: internalPlaylist = await ImportPlaylist(); << must be in another async method.

			List<TagInfo> tagInfos = new List<TagInfo>();

			if (File.Exists(pathofile)) {
				string[] lines = File.ReadAllLines(pathofile);
				//BUILT FOR .m38u FILES.

				//Loop thru and ignore all arrays starting with a # or if total characters > 8 (C:/a.mp3 is 8 chars)
				//TODO: Do a regex that validates filepaths.
				//See lowest reply: https://stackoverflow.com/questions/12947405/string-path-validation

				foreach (string line in lines) {
					if (line[0] != '#' && line.Length > 8) {

						//Add each item into tempTags, rejecting those paths where the tag can't be found.
						var tag = ConvertToTagInfo(GetTag(line));
						if (tag.filepath != "") {
							tagInfos.Add(tag);
						}
					}
				}

				//temp now holds all (hopefully) valid filepaths. Transfer them into a new Playlist Object!

				if (tagInfos.Count != 0) { //If ther isn't any valid filepaths, Log an error and return null.

					//Create a new Playlist, loop through the new TagInfo in Playlist, and write the TAGS.

					ExternalPlaylist finalPlaylist = new ExternalPlaylist() {

						//Add the name and array of tags to the name var in tempPlaylist
						name = Path.GetFileName(pathofile).Split('.')[0],
						songs = tagInfos
					};

					return finalPlaylist;
				} else {
					Logger.Error("Loading Playlist: No valid songs found in playlist! " + pathofile);
				}

			} else {
				Logger.Error("Loading Playlist: File path of Playlist does not exist: " + pathofile);
			}
			return null;
		}

		#endregion

		#region Internal Saving and Parsing of .arientpl file

		//Save Playlist class to file on disk using .arientpl v1.0
		public static void SavePlaylistToDisk(ExternalPlaylist playlist, bool isNewPlaylist = false) {
			string writeData = "";

			//Create Header
			writeData += ".artpl file version|1.0\n\n";

			//Add playlist name and any other settings.
			writeData += "PlaylistName|" + playlist.name +
			"\nCurrentSongIndex|" + playlist.currentSongIndex +
			"\nCurrentSongPos|" + playlist.currentSongPos +
			"\nShuffle|" + playlist.shuffle +
			"\nRepeat|" + playlist.repeatPlaylist +
			"\n\n";

			if (playlist.songs.Count > 0) {
				//Add individual songs, items seperated by |
				foreach (TagInfo tag in playlist.songs) {
					writeData +=
					tag.filepath + "|" +
					tag.title + "|" +
					tag.artist + "|" +
					tag.album + "|" +
					tag.albumartist + "|" +
					tag.year + "|" +
					tag.duration + "|" +
					tag.genre + "|" +
					tag.track + "|" +
					tag.disc + "|" +
					tag.bitrate + "|" +
					tag.frequency + "|" +
					tag.format + "|" +
					tag.size + "|" +
					tag.mood + "|" +
					tag.rating + "|" +
					tag.bpm + "\n";
				}
			}

			
			//Create the Subfolder directory if dosent exist.
			string path = Directory.GetCurrentDirectory() + playlistSubfolder;
			Directory.CreateDirectory(path);
			//Write to file. Force overwrite any existsing files.
			File.WriteAllText(path + playlist.name + playlistExtension, writeData);
			Logger.Debug("Wrting playlist: " + playlist.name);

		}

		//Load a Playlist file from disk.
		public static ExternalPlaylist LoadPlaylistFromDisk(string filepath) {

			//Create a Object to return.
			ExternalPlaylist playlist = null;

			//Check if file exists.
			if (File.Exists(filepath)) {
				playlist = new ExternalPlaylist(); //override null value to prepare for assignment.

				//load contents of file to a string array
				string[] rawLines = File.ReadAllLines(filepath);

				//Check version of save file
				string version = rawLines[0].Split('|')[1];

				int indexOffset = -1;//for use on playlist.songs. When i = 8, playlist.songs index must be 0.

				//Loop through every single line of the file.
				for (int i = 0; i < rawLines.Length; i++) {

					if (rawLines[i].Trim(' ') == "") //skip all empty lines
						continue;

					//Check version and apply different method of parsing if avail.
					switch (version) {
						case "1.0":
							
							playlist.filepath = filepath; //grab the filepath directly.
							string[] splitline = rawLines[i].Split('|');
							
							//Assigning the Playlist setting variables. Top few lines of the file.
							switch (splitline[0]) {
								case "PlaylistName":
									playlist.name = splitline[1];
									break;
								case "CurrentSongIndex":
									playlist.currentSongIndex = int.Parse(splitline[1]);
									break;
								case "CurrentSongPos":
									playlist.currentSongPos = double.Parse(splitline[1]);
									break;
								case "Shuffle":
									if (splitline[1] == "True") {
										playlist.shuffle = true;
									} else {
										playlist.shuffle = false;
									}
									break;
								case "Repeat":
									if (splitline[1] == "True") {
										playlist.repeatPlaylist = true;
									} else {
										playlist.repeatPlaylist = false;
									}
									break;
								default:
									//Assign tags of each song!

									if (splitline.Length > 3) {
										//playlist.songs length assigned. Write splitline data into playlist.songs.
										TagInfo newTag = new TagInfo();
										newTag.filepath = splitline[0];
										newTag.title = splitline[1];
										newTag.artist = splitline[2];
										newTag.album = splitline[3];
										newTag.albumartist = splitline[4];
										newTag.year = splitline[5];
										newTag.duration = double.Parse(splitline[6]);
										newTag.genre = splitline[7];
										newTag.track = splitline[8];
										newTag.disc = splitline[9];
										newTag.bitrate = int.Parse(splitline[10]);
										newTag.frequency = int.Parse(splitline[11]);
										newTag.format = splitline[12];
										newTag.size = long.Parse(splitline[13]);
										newTag.mood = splitline[14];
										newTag.rating = splitline[15];
										newTag.bpm = splitline[16];
										playlist.songs.Add(newTag);
									}

									//playlist.song assigned for this line.
									break;
							}
							break;
					}
				}
			} else {
				Logger.Error("Loading Playlist from disk: Could not find the saved playlist named " + filepath);
			}
			return playlist;
		}

		//Loads ALL playlists in the saved data folder.
		public static ExternalPlaylist[] LoadAllPlaylistsFromDisk() {
			List<ExternalPlaylist> playlists = new List<ExternalPlaylist>();
			string dataFolderPath = Directory.GetCurrentDirectory() + playlistSubfolder;
			Directory.CreateDirectory(dataFolderPath);
			string[] files = Directory.GetFiles(dataFolderPath,"*" + playlistExtension);

			foreach (string file in files) {
				playlists.Add(LoadPlaylistFromDisk(file));
			}
			if (playlists.Count == 0) {
				return null;
			}
			return playlists.ToArray();
		}

		#endregion

		#region Misc Helper Methods
		//Loads TAG_INFO from a music file and returns it.
		public static TAG_INFO GetTag(string path) {
			TAG_INFO tag_info = null;

			if (File.Exists(path)) {
				tag_info = BassTags.BASS_TAG_GetFromFile(path);
			} else {
				Logger.Error("Unable to load tag from file: " + path);
			}

			return tag_info;
		}

		public static TagInfo ConvertToTagInfo(TAG_INFO old) {

			TagInfo tagInfo = new TagInfo();

			if (old != null) {
				//Map all used stuff from TAG_INFO into toreturn.
				tagInfo.filepath = old.filename;
				tagInfo.title = old.title;
				tagInfo.artist = old.artist;
				tagInfo.album = old.album;
				tagInfo.albumartist = old.albumartist;
				tagInfo.year = old.year;
				tagInfo.duration = old.duration;
				tagInfo.genre = old.genre;
				tagInfo.track = old.track;
				tagInfo.disc = old.disc;
				tagInfo.bitrate = old.bitrate;
				tagInfo.frequency = old.channelinfo.freq;
				tagInfo.size = new FileInfo(old.filename).Length;
				tagInfo.rating = old.rating;

				switch (old.channelinfo.ctype) {
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_MUSIC_MO3:
						tagInfo.format = "MO3";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_MUSIC_MOD:
						tagInfo.format = "MOD";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_MUSIC_MTM:
						tagInfo.format = "MTM";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_MUSIC_S3M:
						tagInfo.format = "S3M";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_MUSIC_XM:
						tagInfo.format = "XM";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_AAC:
						tagInfo.format = "AAC";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_AC3:
						tagInfo.format = "AC3";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_ADX:
						tagInfo.format = "ADX";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_AIFF:
						tagInfo.format = "WAV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_AIX:
						tagInfo.format = "AIX";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_ALAC:
						tagInfo.format = "ALAC";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_AM:
						tagInfo.format = "AM";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_APE:
						tagInfo.format = "APE";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_CA:
						tagInfo.format = "CA";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_CD:
						tagInfo.format = "CD";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_DSD:
						tagInfo.format = "DSD";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_FLAC:
						tagInfo.format = "FLAC";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_FLAC_OGG:
						tagInfo.format = "FLAC OGG";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MF:
						tagInfo.format = "MF";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MIDI:
						tagInfo.format = "MIDI";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MP1:
						tagInfo.format = "MP1";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MP2:
						tagInfo.format = "MP2";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MP3:
						tagInfo.format = "MP3";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MP4:
						tagInfo.format = "MP4";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_MPC:
						tagInfo.format = "MPC";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_OFR:
						tagInfo.format = "OFR";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_OGG:
						tagInfo.format = "OGG";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_OPUS:
						tagInfo.format = "OPUS";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_TTA:
						tagInfo.format = "TTA";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_VIDEO:
						tagInfo.format = "VIDEO";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WAV:
						tagInfo.format = "WAV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WAV_FLOAT:
						tagInfo.format = "WAV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WAV_PCM:
						tagInfo.format = "WAV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WINAMP:
						tagInfo.format = "WINAMP";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WMA:
						tagInfo.format = "WMA";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WMA_MP3:
						tagInfo.format = "WMA";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WV:
						tagInfo.format = "WV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WV_H:
						tagInfo.format = "WV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WV_L:
						tagInfo.format = "WV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_STREAM_WV_LH:
						tagInfo.format = "WV";
						break;
					case Un4seen.Bass.BASSChannelType.BASS_CTYPE_UNKNOWN:
						tagInfo.format = "UNK";
						break;
					default:
						tagInfo.format = "UNK";
						break;
				}
			} else { tagInfo.filepath = ""; }

			return tagInfo;
		}
		#endregion

		#region NTFS Unique Identifier Getter
		//See: https://stackoverflow.com/questions/1866454/unique-file-identifier-in-windows
		//Things to note: ID will never change on NTFS systems, unless deleted.
		//If moved from drive to drive, ID will change. If file is deleted and replaced, ID will change.
		//If used on FAT system, ID MAY change over time due to how the system stores bytes.
		//So far, not sure if ID will change on ext4 on linux.

		//FOR USE ON LOCAL SYSTEM ONLY. so the ext4 problem dosen't matter.

		[DllImport("kernel32.dll")]
		public static extern bool GetFileInformationByHandle(IntPtr hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);

		public struct BY_HANDLE_FILE_INFORMATION {
			public uint FileAttributes;
			public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
			public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
			public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
			public uint VolumeSerialNumber;
			public uint FileSizeHigh;
			public uint FileSizeLow;
			public uint NumberOfLinks;
			public uint FileIndexHigh;
			public uint FileIndexLow;
		}

		public static string GetUniqueFileID(string path) {
			BY_HANDLE_FILE_INFORMATION objectFileInfo = new BY_HANDLE_FILE_INFORMATION();

			FileInfo fi = new FileInfo(path);
			FileStream fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

			GetFileInformationByHandle(fs.Handle, out objectFileInfo);

			fs.Close();

			ulong fileIndex = ((ulong)objectFileInfo.FileIndexHigh << 32) + (ulong)objectFileInfo.FileIndexLow;

			return fileIndex.ToString();

		}
		#endregion
	}


	public static class Logger {

		public static readonly DateTime dateTime = DateTime.Now;

		static readonly string currentSession = DateTime.Now.ToString().Replace("/", "-").Replace(":", ".").Replace(" ", "_");

		public static void Debug(string lines) {
			//Write the string to a file.append mode is enabled so that the log
			//lines get appended to  test.txt than wiping content and writing the log

			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\Log.txt", true)) {
				file.WriteLine("[" + DateTime.Now + "] " + lines);
			}
		}

		public static void Warning(string lines) {
			//Write the string to a file.append mode is enabled so that the log
			//lines get appended to  test.txt than wiping content and writing the log

			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\Log.txt", true)) {
				file.WriteLine("[" + DateTime.Now + "] WARNING:" + lines);
			}
		}

		public static void Error(string lines) {
			//Write the string to a file.append mode is enabled so that the log
			//lines get appended to  test.txt than wiping content and writing the log

			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\Log.txt", true)) {
				file.WriteLine("[" + DateTime.Now + "] ERROR: " + lines);
			}
		}
	}
}
