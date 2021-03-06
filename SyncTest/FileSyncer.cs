using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace SyncTest {
	class FileSyncer {

		static void Main(string[] args) {
			try {
				////RESET
				//DirectoryInfo di = new DirectoryInfo(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\");
				//DirectoryInfo dis = new DirectoryInfo(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\");
				//foreach (FileInfo file in di.GetFiles()) {
				//	file.Delete();
				//}
				//foreach (DirectoryInfo dir in di.GetDirectories()) {
				//	dir.Delete(true);
				//}
				//foreach (FileInfo file in dis.GetFiles()) {
				//	file.Delete();
				//}
				//foreach (DirectoryInfo dir in dis.GetDirectories()) {
				//	dir.Delete(true);
				//}
				////COPY OVER CLIENT
				//foreach (string dirPath in Directory.GetDirectories(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", "*", SearchOption.AllDirectories)) {
				//	Directory.CreateDirectory(dirPath.Replace(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\"));
				//}
				//foreach (string newPath in Directory.GetFiles(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", "*.*", SearchOption.AllDirectories)) {
				//	File.Copy(newPath, newPath.Replace(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\"), true);
				//}
				////COPY OVER SERVER
				//foreach (string dirPath in Directory.GetDirectories(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", "*", SearchOption.AllDirectories)) {
				//	Directory.CreateDirectory(dirPath.Replace(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\"));
				//}
				//foreach (string newPath in Directory.GetFiles(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", "*.*", SearchOption.AllDirectories)) {
				//	File.Copy(newPath, newPath.Replace(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\"), true);
				//}
				////INITIALIZE
				//SyncButton(); //sync 0
				//Console.WriteLine("================================================================================\n");
				//#region Dual Rename Chain client & server
				////rename, dual chain effect on client + server
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\aa.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\69.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\69.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\aa.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\b.mp3");

				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\aa.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\69.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\aa.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\69.mp3");
				////SyncButton();
				//#endregion

				//#region Rename same file on server/client to diff names
				////rename same file to 2 names
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\aa.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\bb.mp3");
				////SyncButton();
				//#endregion

				//#region Drag-drop replacement of a file, on server + client
				////Replacing file with new one, same name
				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a.mp3");
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a.mp3");
				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3");
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3");
				////SyncButton();
				//#endregion

				//#region old client test
				////Updating OLD client.
				////server: 69 -> 692 -> 69, a -> aa -> a1, b -> bb, add newfile, modify 69, modify kokoro
				////Old client: a -> b, b -> a, add newfile, delete coma, modify 69
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.datacpy");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\69.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\692.mp3");
				////SyncButton();
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\692.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\69.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\aa.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\bb.mp3");
				////SyncButton();

				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\aa.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\b.mp3");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\bb.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3");
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\newfile.mp3");

				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\aa.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\a1.mp3");
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\coma.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\newfile.mp3");

				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\coma.mp3");
				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data");

				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.datacpy", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data");
				////Console.WriteLine("!!!!!!!!!!!!!!Edit Client .sync to 1, modify 69 client + server, modify server kokoro!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				////Console.ReadKey();
				////SyncButton();
				//#endregion

				//#region old client modifying test
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.datacpy");
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\newfile.mp3");
				////SyncButton();

				////Console.WriteLine("!!!!!!!!!!!!!!Modify newfile client!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				////Console.ReadKey();
				////SyncButton();

				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data");
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.datacpy", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data");
				////Console.WriteLine("!!!!!!!!!!!!!!Edit Client .sync to 1, !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
				////Console.ReadKey();
				////SyncButton();
				//#endregion

				//#region New Client Join halfway
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b1.mp3");
				////SyncButton();
				////File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b1.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b2.mp3");
				////SyncButton();
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\aiaiaia.mp3");
				////SyncButton();
				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.data");
				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\.sync");
				//////client has extra files 
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\oonewclientfile.mp3");
				//////client missing some files
				////File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3");
				//////server add new file
				////File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\oonewclientfile.mp3");
				////SyncButton();
				//#endregion

				//#region Server Reset
				//File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b1.mp3");
				//SyncButton();
				//File.Move(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b1.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b2.mp3");
				//SyncButton();
				//File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\b-leaf.mp3");
				//SyncButton();
				//File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\.data");
				//File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\.sync");
				////client has extra files 
				//File.Copy(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\test\b.mp3", @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\oonewclientfile.mp3");
				////client missing some files
				//File.Delete(@"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\a.mp3");
				//Console.ReadKey();
				//SyncButton();
				//#endregion

			} catch (Exception e) {
				Console.WriteLine("UNIT TEST: " + e.Message);
			}
			SyncButton();
		}

		enum ChangeType { Delete, Add, Rename, Modified }

		//Hack for quickly converting strings into enums
		//https://stackoverflow.com/questions/16100/convert-a-string-to-an-enum-in-c-sharp/38711#38711
		static Dictionary<string, ChangeType> strToChangeType = new Dictionary<string, ChangeType>() {
			{"Delete", ChangeType.Delete },
			{"Add", ChangeType.Add },
			{"Rename", ChangeType.Rename },
			{"Modified", ChangeType.Modified },
		};

		class SyncEvent {

			//Builds a new SyncEvent
			public SyncEvent(string _syncEventNumber, string _machineID, string _timeStamp) {
				syncEventNumber = _syncEventNumber;
				machineID = _machineID;
				timeStamp = _timeStamp;
				changes = new List<Change>();
			}

			//Replicates a new SyncEvent using an existing one.
			public SyncEvent(SyncEvent syncEvent) {
				syncEventNumber = syncEvent.syncEventNumber;
				machineID = syncEvent.machineID;
				timeStamp = syncEvent.timeStamp;
				changes = new List<Change>(syncEvent.changes);
			}

			public void AddNewChange(string fileName, ChangeType changeType, string newFileName) {
				changes.Add(new Change(fileName, changeType, newFileName));
			}

			public void ChangeFileName(int index, string newName) {
				if (index < changes.Count) {
					changes[index] = new Change(newName, changes[index].changeType, changes[index].renamedRFileName);
				}
			}

			public string syncEventNumber;
			public string machineID;
			public string timeStamp;
			public List<Change> changes;

			public struct Change {
				public string rFileName;
				public ChangeType changeType;
				public string renamedRFileName;
				public Change(string _rFilename, ChangeType _changeType, string _renamedRFielName) {
					rFileName = _rFilename;
					changeType = _changeType;
					renamedRFileName = _renamedRFielName;
				}
				public Change(Change change) {
					rFileName = change.rFileName;
					changeType = change.changeType;
					renamedRFileName = change.renamedRFileName;
				}
			}
		}

		static bool debug = true;

		static string clientFolder = @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\CLIENT\";
		static string serverFolder = @"C:\PERSONAL FILES\WORK\APP\Icarus\SyncTest\TEST\SERVER\";

		static int globalNextSENumber = 0; //global SE Number for use to give new updates that are to be added to serverSyncs. Increments when new updates are added.
		static int clientNextSENumber = 0; //NEXT number of the client, before this sync!
		static int serverCurrSENumber = 0; //CURRENT number of the server, before this sync!
		//Entry point: Sync Button pressed!
		public static void SyncButton() {
			// ====================== Check if directories exist. ==============================
			#region Check Directories Exist
			if (!Directory.Exists(serverFolder)) {
				Console.WriteLine("server folder \'" + serverFolder + "\' does not exist. Attempting to create directory!");
				Directory.CreateDirectory(serverFolder);
				if (!Directory.Exists(serverFolder)) {
					Console.WriteLine("server folder \'" + serverFolder + "\' not able to be created! Aborting");
					return;
				}
			}

			if (!Directory.Exists(clientFolder)) {
				Console.WriteLine("client folder \'" + clientFolder + "\' does not exist. Aborting sync!");
				Directory.CreateDirectory(clientFolder);
				if (!Directory.Exists(clientFolder)) {
					Console.WriteLine("client folder \'" + clientFolder + "\' not able to be created! Aborting");
					return;
				}
			}
			#endregion
			// ====================== Check if files exist. ==============================
			#region Check Files Exist
			//Check if server .data exists.
			//if not exist, create new .data and .sync.
			Console.WriteLine("Checking data files for server...");
			if (!File.Exists(Path.Join(serverFolder, ".data"))) {

				//TODO: Acutally check if .data is parasable. Rebuild if not parsable.
				//Todo: Maybe attempt a repair on the file?
				Console.WriteLine("server .data file not exist, building one!");
				CreateDataFile(serverFolder);

			}

			if (!File.Exists(Path.Join(serverFolder, ".sync"))) {

				//TODO: Acutally check if .data is parasable. Rebuild if not parsable.
				//Todo: Maybe attempt a repair on the file?
				Console.WriteLine("server .sync file not exist, building one!");
				CreateSyncFile(serverFolder, DateTime.Now.ToString("yyyyMMddHHmmss"));

			}

			//Check if client .data exists.
			//if not exist, create new .data and .sync.
			Console.WriteLine("Checking data files for client...");
			if (!File.Exists(Path.Join(clientFolder, ".data"))) {

				//TODO: Acutally check if .data is parasable. Rebuild if not parsable.
				//Todo: Maybe attempt a repair on the file?
				Console.WriteLine("server .data file not exist, building one!");
				CreateDataFile(clientFolder);

			}

			if (!File.Exists(Path.Join(clientFolder, ".sync"))) {

				//TODO: Acutally check if .data is parasable. Rebuild if not parsable.
				//Todo: Maybe attempt a repair on the file?
				Console.WriteLine("server .sync file not exist, building one!");
				CreateSyncFile(clientFolder, DateTime.Now.ToString("yyyyMMddHHmmss"));

			}

			//Used in resetting the server .data and .sync files
			string serverDateVersionNumber = "";
			string clientDateVersionNumber = "";
			LoadSyncDateVersionNumber(serverFolder, ref serverDateVersionNumber);
			LoadSyncDateVersionNumber(clientFolder, ref clientDateVersionNumber);

			//If client .sync's version does not match with server's, delete the .data and .sync files of client and re-generate.
			if (serverDateVersionNumber != clientDateVersionNumber) {
				Console.WriteLine("Server and Client .sync versions do not match. Deleting and regenerating Client .sync and .data files!");
				if (File.Exists(Path.Join(clientFolder, ".sync"))) {
					File.Delete(Path.Join(clientFolder, ".sync"));
				}
				CreateSyncFile(clientFolder, DateTime.Now.ToString("yyyyMMddHHmmss"));
				if (File.Exists(Path.Join(clientFolder, ".data"))) {
					File.Delete(Path.Join(clientFolder, ".data"));
				}
				CreateDataFile(clientFolder);
			}

			#endregion
			// ====================== Load in from .data and .sync files ==============================
			#region Load Data
			// !!!!!!! Save all parsed results somewhere to be used until the whole sync process is over !!!!!!

			Console.WriteLine("Loading in .data and .sync files...");

			//.data files
			//KEY: relativeFilepath, VALUE: string array [LocalID, LastModified]
			Dictionary<string, string[]> serverData = new Dictionary<string, string[]>();
			Dictionary<string, string[]> clientData = new Dictionary<string, string[]>();

			//.sync files
			//Refer to SyncEvent class. Oldest top, newest bottom. .sync file shld follow this format too.
			List<SyncEvent> serverSyncs = new List<SyncEvent>();
			List<SyncEvent.Change> clientRollbacks = new List<SyncEvent.Change>(); //for rolling back changes as server takes precedence
			List<SyncEvent.Change> serverRollbacks = new List<SyncEvent.Change>(); //for rolling back changes in case as needed.

			LoadDataFile(serverFolder, ref serverData);
			LoadDataFile(clientFolder, ref clientData);

			if (debug) {
				Console.WriteLine("\nSERVER DATA LOADED:");
				foreach (KeyValuePair<string, string[]> item in serverData) {
					Console.WriteLine(item.Key + "|" + item.Value[0] + "|" + item.Value[1]);
				}
				if (serverData.Count == 0) Console.WriteLine("[empty]");

				Console.WriteLine("\nCLIENT DATA LOADED:");
				foreach (KeyValuePair<string, string[]> item in clientData) {
					Console.WriteLine(item.Key + "|" + item.Value[0] + "|" + item.Value[1]);
				}
				if (clientData.Count == 0) Console.WriteLine("[empty]");
			}

			LoadSyncFile(serverFolder, ref serverSyncs);
			LoadDiskNextSENumber(serverFolder, ref globalNextSENumber);
			LoadDiskNextSENumber(clientFolder, ref clientNextSENumber);
			serverCurrSENumber = globalNextSENumber - 1;

			//Used in Merging & Conflict, and FileIO.
			int SENumberOffset = 0;
			if (serverSyncs.Count > 0) {
				SENumberOffset = int.Parse(serverSyncs[0].syncEventNumber);
			}

			#endregion
			// ====================== Check for sync updates, Merging & Conflict Management ==============================
			#region Get Sync Changes for Server
			//Compare server .data file to server files on disk.
			Console.WriteLine("\nChecking file changes for server...");
			SyncEvent serverChanges = GetChangesFromDisk(serverFolder, ref serverData);

			//if changes are NOT NULL, write to .sync, as a new entry IMMEDIATELY.
			if (serverChanges != null) {
				Console.WriteLine("Server changes found!");
				SyncEventConflictResolver(in serverSyncs, ref serverChanges);
				FixRenameSwapScenario(ref serverChanges, ref clientRollbacks);
				AddToServerSyncEvents(ref serverSyncs, ref serverChanges);
			} else {
				Console.WriteLine("No server changes found.");
			}

			//Compare client .data file to client files on disk.
			Console.WriteLine("\nChecking file changes for client...");
			SyncEvent clientChanges = GetChangesFromDisk(clientFolder, ref clientData);

			#endregion
			#region Get Sync Changes for Client, & do Conflict management
			// Compare client changes to server changes, cancel out actions that have alr been done.
			if (clientChanges != null) {
				Console.WriteLine("Client changes found!");
				// Handle any conflicts in the merge.
				Console.WriteLine("Updating outdated client changes into clientRollbacks (if any)");
				UpdateClientOldChanges(in serverSyncs, ref clientChanges, ref clientRollbacks);

				Console.WriteLine("Processing changes to remove conflicts before adding to serverSyncs...");
				FixClientRepeatedActions(ref serverChanges, ref clientChanges, ref clientRollbacks);
				SyncEventConflictResolver(in serverSyncs, ref clientChanges);
				FixClientRenameConflict(ref clientChanges, ref clientRollbacks, ref serverChanges, in serverData);
				FixRenameSwapScenario(ref clientChanges, ref serverRollbacks);
				//clientChanges is now free of any potential conflicts.

				// Finally, the merged client changes can be appended to server's .sync (but don't write).
				if (clientChanges.changes.Count > 0) {
					Console.WriteLine("Processed changes valid, adding to serverSync.");
					AddToServerSyncEvents(ref serverSyncs, ref clientChanges);
				} else {
					Console.WriteLine("No more changes left after processing. No SyncEvent will be added for Client.");
				}
			} else {
				Console.WriteLine("No client changes found.");
			}
			#endregion
			// ====================== File IO Actions =====================
			#region File IO

			if (serverRollbacks.Count > 0) {
				//Do server rollback file IO.
				Console.WriteLine("\nDoing Server Rollback file IO...");
				foreach (SyncEvent.Change change in serverRollbacks) {
					PerformFileIO(clientFolder, serverFolder, change, ref serverData);
				}
				Console.WriteLine("Done!");
			}
			//Do server file IO.
			Console.WriteLine("\nDoing Client to Server file IO...");
			//clientChanges is already the perfect block to directly carry out actions on Client. Just do actions as is.
			if (clientChanges != null)
				foreach (SyncEvent.Change change in clientChanges.changes) {
					PerformFileIO(clientFolder, serverFolder, change, ref serverData);
				}
			Console.WriteLine("Done!");
			if (clientRollbacks.Count > 0) {
				//Do client rollback file IO.
				Console.WriteLine("\nDoing Client Rollback file IO...");
				foreach (SyncEvent.Change change in clientRollbacks) {
					PerformFileIO(serverFolder, clientFolder, change, ref clientData);
				}
				Console.WriteLine("Done!");
			}

			//Do client file IO.
			Console.WriteLine("\nDoing Server to Client file IO...");
			//serverChanges is already the perfect block to directly carry out actions on Client. Just do actions as is.
			if (serverChanges != null)
				foreach (SyncEvent.Change change in serverChanges.changes) {
					PerformFileIO(serverFolder, clientFolder, change, ref clientData);
				}
			Console.WriteLine("Done!");
			#endregion
			// ====================== Writing .sync & .data files ===================
			#region Writing .sync & .data files

			// Write the entirety of the serverside .sync file into a new .sync file, overwrite.
			Console.WriteLine("\nWriting server .sync file...");
			WriteSyncFile(serverFolder, in serverSyncs, globalNextSENumber, serverDateVersionNumber);
			Console.WriteLine("Writing client .sync file...");
			serverSyncs = null;
			WriteSyncFile(clientFolder, in serverSyncs, globalNextSENumber, serverDateVersionNumber);

			// Write the entirety of .data to both server and client.
			Console.WriteLine("Writing server .data file...");
			WriteDataFile(serverFolder, in serverData);

			Console.WriteLine("Writing client .data file...");
			WriteDataFile(clientFolder, in clientData);
			#endregion

			Console.WriteLine("\nFiles synchronized!");
		}

		public static void ResetClientSync() {
			Console.WriteLine("Resetting server .sync!");
			if (File.Exists(Path.Join(clientFolder, ".sync"))) {
				File.Delete(Path.Join(clientFolder, ".sync"));
			}
			if (File.Exists(Path.Join(clientFolder, ".data"))) {
				File.Delete(Path.Join(clientFolder, ".data"));
			}
		}

		public static void ResetServerSync() {
			Console.WriteLine("Resetting client .sync!");
			if (File.Exists(Path.Join(serverFolder, ".sync"))) {
				File.Delete(Path.Join(serverFolder, ".sync"));
			}
			if (File.Exists(Path.Join(serverFolder, ".data"))) {
				File.Delete(Path.Join(serverFolder, ".data"));
			}
		}

		// ================= Helper Methods ===========================

		#region FileIO Creation/Loader helpers
		//Takes in target folder path and builds a .data file right there.
		//builds using whatever music files exists in that folder and subfolder.
		static void CreateDataFile(string path) {
			Directory.CreateDirectory(path);
			using (StreamWriter sw = File.CreateText(Path.Join(path, ".data"))) {
				sw.WriteLine("#1.0 Data File");
				sw.WriteLine(path);
				sw.WriteLine("");
			}
		}

		//Takes in target folder path and builds a .sync file right there.
		static void CreateSyncFile(string path, string dateVersionNumber) {
			Directory.CreateDirectory(path);
			using (StreamWriter sw = File.CreateText(Path.Join(path, ".sync"))) {
				sw.WriteLine("1.0 Sync File|" + dateVersionNumber);
				sw.WriteLine("");
				sw.WriteLine("0"); //Next sync number
			}
		}

		//Loads the .data file in the specific folder.
		//KEY: relativeFilepath, VALUE: string array [LocalID, LastModified]
		static void LoadDataFile(string path, ref Dictionary<string, string[]> dict) {
			if (!File.Exists(Path.Join(path, ".data"))) {
				Console.WriteLine("ERROR: .data file not found at path: " + path + ", unable to load. Did program not manage to create file at this path location?");
				return;
			}

			dict.Clear();

			int skipcount = 0;
			foreach (var line in File.ReadLines(Path.Join(path, ".data"))) {
				//skip the first 3 lines
				if (skipcount < 3) {
					skipcount++;
					continue;
				}

				//each readline is an entry now. Add them to the dictionary.
				//parts[0]: relative path
				//parts[1]: LocalID
				//parts[2]: last modified
				string[] parts = line.Split('|');
				dict.Add(parts[0], new string[] { parts[1], parts[2] });
			}
		}

		//Loads the .sync file in the specific folder.
		//An array of SyncEvent objects, each with a List of changes. Oldest at top, newest at bottom
		static void LoadSyncFile(string path, ref List<SyncEvent> list) {
			if (!File.Exists(Path.Join(path, ".sync"))) {
				Console.WriteLine("ERROR: .sync file not found at path: " + path + ", unable to load. Did program not manage to create file at this path location?");
				return;
			}

			list.Clear();

			int skipcount = 0;
			foreach (var line in File.ReadLines(Path.Join(path, ".sync"))) {
				//skip the first 3 lines
				if (skipcount < 3) {
					skipcount++;
					continue;
				}
				//If first char starts with #, new sync event!
				if (line.Length > 1 && line[0] == '#') { //add sync event
					string[] temp = line.Remove(0, 1).Split('|'); //remove the # and split
					list.Add(new SyncEvent(temp[0], temp[1], temp[2]));

				} else { //add individual sync change entries
					string[] temp = line.Split('|');
					if (temp.Length >= 3) {
						list[^1].AddNewChange(temp[0], strToChangeType[temp[1]], temp[2]); //list[^1] is the last element in the list
					}
				}

			}

		}

		//Reads the SyncEventNumber from the 3rd line in the .sync file.
		//If number is -1, floor it to 0 to prevent array indexes from going out of range.
		static void LoadDiskNextSENumber(string path, ref int nextSENumber) {
			if (!File.Exists(Path.Join(path, ".sync"))) {
				Console.WriteLine("ERROR: .sync file not found at path: " + path + ", unable to load. Did program not manage to create file at this path location?");
				return;
			}

			int skipcount = 0;
			foreach (var line in File.ReadLines(Path.Join(path, ".sync"))) {
				//skip the first 2 lines
				if (skipcount < 2) {
					skipcount++;
					continue;
				}
				//skip everything, go straight to third line, read the number and return.
				nextSENumber = int.Parse(line);
				return;
			}
		}

		//Reads the Date version number from .sync file, from the 1st line of the file.
		static void LoadSyncDateVersionNumber(string path, ref string dateVersion) {
			if (!File.Exists(Path.Join(path, ".sync"))) {
				Console.WriteLine("ERROR: .sync file not found at path: " + path + ", unable to load. Did program not manage to create file at this path location?");
				return;
			}
			foreach (var line in File.ReadLines(Path.Join(path, ".sync"))) {
				//Get the dateversion part in the first line.
				//1.0 Sync File|datetimeversion
				dateVersion = line.Split('|')[1];
				return;
			}
		}

		//Compares current serverData/clientData to what's on the disk right now, and returns a SyncEvent
		//dataFile is the .data parsed prior, belonging to either client or server.
		//ALSO, update the data in .data immediately.
		static SyncEvent GetChangesFromDisk(string path, ref Dictionary<string, string[]> data) {

			//A list of "entries" to keep. Will use this later after searching thru whole directory
			//to see which entries are leftover. Leftovers are files that are DELETED.
			List<string> dataFileTemp = new List<string>(data.Keys);

			//SyncNumber does not matter here! Will override next time!
			//Create a new SyncEvent, this will be returned and later used to compare against other things.
			SyncEvent newUpdate = new SyncEvent(globalNextSENumber.ToString(), path == serverFolder ? "SERVER" : Environment.MachineName, DateTime.Now.ToString("yyyyMMddHHmmss"));

			//Temporary lists to hold data for editing .data
			//Required to prevent conflicts, especially during renaming. removes must happen first all at once, then adds.
			List<string> toRemoveData = new List<string>();
			Dictionary<string, string[]> toAddData = new Dictionary<string, string[]>();

			//Parse the disk files, and compare to data!
			//Browse each and every one of the song files in this dir, and search on the respective .data file
			foreach (string fullFilePath in Directory.GetFiles(path, "*", SearchOption.AllDirectories)) {

				//If not a music file, skip.
				if (!IsMusicFileExtension(Path.GetExtension(fullFilePath))) continue;

				//get the LocalId of this file
				string localId = GetUniqueFileID(fullFilePath);

				//Removes the front part of the filePath to give the rFilePath
				string relativeFilePath = fullFilePath.Replace(path, "");

				//Scan the entire .data file for the existence of this localId of this file.
				string matchedKey = FindKeyInDataDict(localId, in data);
				if (matchedKey != "") {
					//found localId. Same file exists on disk and .data, can be either a RENAME or nothing, and/or MODIFIED.

					//check for RENAME. if relativeFilePath is not equal to the matchedKey, RENAMED!
					if (relativeFilePath != matchedKey) {
						//RENAMED!
						newUpdate.AddNewChange(matchedKey, ChangeType.Rename, relativeFilePath);
						//Update data!
						toRemoveData.Add(matchedKey);
						toAddData.Add(relativeFilePath, new string[] { localId, data[matchedKey][1] });
					}

					//check for MODIFIED. If the lastModified date on the file is not equal to the one in .data, then MODIFIED.
					if (CompareLastModified(fullFilePath,data[matchedKey][1])) {
						//MODIFIED!
						newUpdate.AddNewChange(matchedKey, ChangeType.Modified, ""); //use RENAMED name or ORIGINAL name? matchedKey = original name, relativeFilePath = new name
						//UPDATE data!
						toAddData.Add(matchedKey, new string[] { localId, File.GetLastWriteTime(fullFilePath).ToString("yyyyMMddHHmmss") });
					}

					//remove entry from dataFileTemp to signify it is accounted for and NOT a deleted file.
					dataFileTemp.Remove(matchedKey);
				} else {
					//localId not found. Must be NEW file.
					newUpdate.AddNewChange(relativeFilePath, ChangeType.Add, "");
					//Update data!
					toAddData.Add(relativeFilePath, new string[] { localId, File.GetLastWriteTime(fullFilePath).ToString("yyyyMMddHHmmss") });
				}
			}

			//leftovers in dataFileTemp are DELETED files.
			foreach (string leftover in dataFileTemp) {	
				newUpdate.AddNewChange(leftover, ChangeType.Delete, "");
				//update data
				toRemoveData.Add(leftover);
			}

			//Do a prata flip so that DELETE always happens first, THEN adds/renames/modifies.
			//Prevents an edge case: DELETE a.mp3, ADD a.mp3. Cannot COPY over cos a.mp3 needs to be DELETED first.
			newUpdate.changes.Reverse();

			//if there were no changes, return null to indicate nothing to update.
			if (newUpdate.changes.Count == 0) {
				if (debug) Console.WriteLine("GETCHANGE: No changes were detected from scanning the disk.");
				return null;
			}

			//update .data using toAddData and toRemoveData.
			//delete entries first.
			foreach (string del in toRemoveData) {
				data.Remove(del);
			}
			//then add new entries
			foreach (KeyValuePair<string, string[]> add in toAddData) {
				//if key alr exists, means just update the values with whatever's in toAddData
				if (!data.ContainsKey(add.Key)) {
					data.Add(add.Key, add.Value);
				} else {
					data[add.Key][0] = add.Value[0];
					data[add.Key][1] = add.Value[1];
				}
			}

			if (debug) {
				Console.WriteLine("\n========= New Changes! ==========");
				foreach (SyncEvent.Change ch in newUpdate.changes) {
					Console.WriteLine(ch.rFileName + "|" + ch.changeType + "|" + ch.renamedRFileName);
				}
			}

			return newUpdate;

			//To check for modify/ last modified. Reusable, only within this method.
			static bool CompareLastModified(string fullFilePath, string dataLastModified) {
				if (ulong.Parse(File.GetLastWriteTime(fullFilePath).ToString("yyyyMMddHHmmss")) > ulong.Parse(dataLastModified)) {
					Console.WriteLine("LocalId has changed! " + fullFilePath);
					return true;
				} else return false;
			}
		}
		#endregion

		#region Conflict Management Helpers
		//If there are old changes to certain files, update the outdated client with them via clientRollbacks.
		//If there are any changes in a file on serverside, and old client also has a change, rollback and remove from clientChanges.
		//After this, client should be on parity with server BEFORE the current serverChanges.
		static void UpdateClientOldChanges(in List<SyncEvent> serverSyncs, ref SyncEvent clientChanges, ref List<SyncEvent.Change> clientRollbacks) {
			//if client is up to date, skip this method. (this method is really big and cursed, loops over and over again because i'm dumb)
			if (clientNextSENumber > serverCurrSENumber) return;
			Console.WriteLine("OLD CLIENT DETECTED. Updating this client with updates it missed out on.");
			//First, filter and compress all changes that can be simplified.
			//Comes in 3 Chunks:
			//ROLLBACK:		Undoing clientChanges for files that the server has touched. (use rollback)
			//PARITY:		Bringing the old client up to date by applying old server changes (use rollback)
			//CLIENTCHANGE:	New changes brought by the client to be applied to server (leave in clientChange)

			//Get all the changes so far into a simple list
			List<SyncEvent.Change> parityChanges = new List<SyncEvent.Change>();
			for (int i = clientNextSENumber; i <= serverCurrSENumber; i++) {
				foreach (SyncEvent.Change ch in serverSyncs[i].changes) {
					parityChanges.Add(new SyncEvent.Change(ch));
				}
			}
			//Handle Deletes and Adds. Remove all changes prior to a Delete, and update the name of the to-be-deleted file to the old name.
			//If an Add is encountered, remove the DELETE altogether.
			for (int i = parityChanges.Count - 1; i >= 0; i--) {

				if (parityChanges[i].changeType != ChangeType.Delete) continue;

				//Start another loop for this particular file
				string currName = parityChanges[i].rFileName;
				bool encounteredAdd = false;

				for (int j = i - 1; j >= 0; j--) {
					//if currName NOT a match to the relevant file, skip.
					if (currName != parityChanges[j].rFileName && currName != parityChanges[j].renamedRFileName) continue;
					if (parityChanges[j].changeType != ChangeType.Add) {
						//update name if any
						// a -> b
						// Delete b
						//looping from bottom up
						if (parityChanges[j].changeType == ChangeType.Rename) currName = parityChanges[j].rFileName;
						parityChanges.RemoveAt(j);
						i--;
						//no need j-- due to looping from back quirk. j element is removed but next element IS the correct next element. i still acts as normal.
						continue;
					} else {
						encounteredAdd = true;
						parityChanges.RemoveAt(j);
						i--;
						//no need j-- due to looping from back quirk. j element is removed but next element IS the correct next element. i still acts as normal.
						break;
					}
				}
				if (encounteredAdd) {
					//remove this DELETE.
					parityChanges.RemoveAt(i);
					//no need i-- due to looping from back quirk. i element is removed but next element IS the correct next element.
				} else {
					//update the DELETE name to the old name (currName)
					parityChanges[i] = new SyncEvent.Change(currName, ChangeType.Delete, "");
				}
			}

			//Unecessary changes due to add/delete have been filtered out.
			//Handle the renames and modifies
			for (int i = parityChanges.Count - 1; i >= 0; i--) {
				if (parityChanges[i].changeType != ChangeType.Rename && parityChanges[i].changeType != ChangeType.Modified) continue;
				string currName = parityChanges[i].rFileName;

				for (int j = i - 1; j >= 0; j--) {
					if (currName != parityChanges[j].rFileName && currName != parityChanges[j].renamedRFileName) continue;

					//Update currName for this loop
					if (parityChanges[j].changeType == ChangeType.Rename) currName = parityChanges[j].rFileName;

					//handle rename
					if (parityChanges[i].changeType == ChangeType.Rename &&
					parityChanges[j].changeType == ChangeType.Rename) {
						parityChanges[i] = new SyncEvent.Change(currName, ChangeType.Rename, parityChanges[i].renamedRFileName);
						parityChanges.RemoveAt(j);
						i--;
						//no need j-- due to looping from back quirk. j element is removed but next element IS the correct next element. i still acts as normal.
						continue;
					}
					//handle modify
					if (parityChanges[i].changeType == ChangeType.Modified &&
					parityChanges[j].changeType == ChangeType.Modified) {
						parityChanges.RemoveAt(j);
						i--;
						//no need j-- due to looping from back quirk. j element is removed but next element IS the correct next element. i still acts as normal.
						continue;
					}
				}
			}

			if (debug) {
				Console.WriteLine("\n===== Old events compressed! From: " + clientNextSENumber + " to: " + serverCurrSENumber + " ======");
				foreach (SyncEvent.Change change in parityChanges) {
					Console.WriteLine(change.rFileName + "|" + change.changeType + "|" + change.renamedRFileName);
				}
			}

			//============ Old changes are compressed and ready to be merged into this current clientChange! ============
			//parityChanges: Only 1 change per file unless RENAME + MODIFIED
			//Brings from old client version to current.
			List<SyncEvent.Change> clientRollbackParity = new List<SyncEvent.Change>(); //to rollback to the correct scenario before client got "split" from server
			List<SyncEvent.Change> clientRollbackUpdate = new List<SyncEvent.Change>(); //to update to be on par with current server

			//ROLLBACK: Undoing clientChanges for files that the server has touched. (use rollback)
			for (int i = 0; i < clientChanges.changes.Count; i++) {
				foreach (SyncEvent.Change parity in parityChanges) {
					//loop through all parity changes until a file match is found.
					//When found, remove clientChanges and add a rollback.
					//rFileName will (almost) always be the correct ID to use, as renames at most happens to ONE change
					//In the case of RENAME + MODIFY, MODIFY will happen RIGHT after RENAME, so just check the renamedRFileName of the element right after and handle that.
					if (clientChanges.changes[i].rFileName == parity.rFileName) {
						if (debug) Console.WriteLine("OLDCLIENT WARNING: a clientChange was found that the server already has touched/modified! Discarding and rolling back this client change.\n"
						+ clientChanges.changes[i].rFileName + "|" + clientChanges.changes[i].changeType + "|" + clientChanges.changes[i].renamedRFileName);

						switch (clientChanges.changes[i].changeType) {
							case ChangeType.Add:
								//Rollback Action: Delete
								clientRollbackParity.Insert(0, new SyncEvent.Change(clientChanges.changes[i].rFileName, ChangeType.Delete, ""));
								if (debug) Console.WriteLine("clientRollbacksEarly add to front: " + clientChanges.changes[i].rFileName + "|DELETE|");
								clientChanges.changes.RemoveAt(i);
								break;

							case ChangeType.Delete:
								//Rollback Action: Add
								//If file is already deleted server-side, let the warnings happen
								clientRollbackParity.Add(new SyncEvent.Change(clientChanges.changes[i].rFileName, ChangeType.Add, ""));
								clientChanges.changes.RemoveAt(i);
								break;

							case ChangeType.Rename:
								//Rollback Action: Rename back to old name
								clientRollbackParity.Insert(0, new SyncEvent.Change(clientChanges.changes[i].renamedRFileName, ChangeType.Rename, clientChanges.changes[i].renamedRFileName + ".rb"));
								clientRollbackParity.Add(new SyncEvent.Change(clientChanges.changes[i].renamedRFileName + ".rb", ChangeType.Rename, clientChanges.changes[i].rFileName));
								clientChanges.changes.RemoveAt(i);
								//Additional check: check if next element is a modify, and if it is the same file.
								//remove the modify if so
								//Next element is i, because the prev element at i was just removed and the whole list shifted.
								if (clientChanges.changes.Count < i &&
								clientChanges.changes[i].changeType == ChangeType.Modified &&
								clientChanges.changes[i].renamedRFileName == parity.rFileName) {
									if (debug) Console.WriteLine("OLDCLIENT WARNING: a clientChange was found that the server already has touched/modified! Discarding and rolling back this client change.\n"
									+ clientChanges.changes[i].rFileName + "|" + clientChanges.changes[i].changeType + "|" + clientChanges.changes[i].renamedRFileName);
									clientChanges.changes.RemoveAt(i);
									i--; //to account for shifting the list one more time
								}
								break;

							case ChangeType.Modified:
								//Rollback Action: NONE
								clientChanges.changes.RemoveAt(i);
								break;
						}
						i--;
						break; //stop looking for parityChanges after a match.
					}
				}
			}
			//At this point, all conflicting clientChanges have been discarded. What's left are valid clientChanges, and valid parityChanges.
			//PARITY: Bringing the old client up to date by applying old server changes (use rollback)
			foreach (SyncEvent.Change parity in parityChanges) {
				switch (parity.changeType) {
					case ChangeType.Add:
						clientRollbackUpdate.Add(new SyncEvent.Change(parity));
						break;

					case ChangeType.Delete:
						clientRollbackUpdate.Insert(0, new SyncEvent.Change(parity));
						break;

					case ChangeType.Rename:
						clientRollbackUpdate.Insert(0, new SyncEvent.Change(parity.rFileName, ChangeType.Rename, parity.rFileName + ".rb")); //add at Middle
						clientRollbackUpdate.Add(new SyncEvent.Change(parity.rFileName + ".rb", ChangeType.Rename, parity.renamedRFileName)); //add at end
						break;

					case ChangeType.Modified:
						clientRollbackUpdate.Add(new SyncEvent.Change(parity));
						break;
				}
			}
			//insert them at the very front of the list, ensures they get done first before rename fixes by server.
			for (int i = clientRollbackUpdate.Count - 1; i >= 0; i--) {
				clientRollbacks.Insert(0, clientRollbackUpdate[i]);
			}
			for (int i = clientRollbackParity.Count - 1; i >= 0; i--) {
				clientRollbacks.Insert(0, clientRollbackParity[i]);
			}
			

			if (debug) {
				Console.WriteLine("\n===== clientRollback as of now ======");
				foreach (SyncEvent.Change change in clientRollbacks) {
					Console.WriteLine(change.rFileName + "|" + change.changeType + "|" + change.renamedRFileName);
				}
			}
		}

		//If client does the same changes as server, discard
		static void FixClientRepeatedActions(ref SyncEvent serverChanges, ref SyncEvent clientChanges, ref List<SyncEvent.Change> clientRollbacks) {
			if (serverChanges == null || clientChanges == null) return;

			for (int i = 0; i < clientChanges.changes.Count; i++) {
				for (int j = 0; j < serverChanges.changes.Count; j++) {
					if (clientChanges.changes[i].changeType == serverChanges.changes[j].changeType &&
					clientChanges.changes[i].rFileName == serverChanges.changes[j].rFileName.Replace(".rb", "") &&
					clientChanges.changes[i].renamedRFileName == serverChanges.changes[j].renamedRFileName) {
						if (debug) Console.WriteLine("FIXREPEAT: Repeated action already done in server! Discarding this client action: " +
						clientChanges.changes[i].rFileName + "|" + clientChanges.changes[i].changeType + "|" + clientChanges.changes[i].renamedRFileName);

						//Discard the change in clientChanges, serverChanges (don't need to update client, EXCEPT for modify) and possible related rollbacks in clientRollbacks
						//Won't affect the .syncs, as the server changes are added to serverSyncs already while serverChanges only affects the actual FileIO operations.

						//Discard Rollback changes include Renames and Modifies
						for (int k = 0; k < clientRollbacks.Count; k++) {
							//renames
							//sv rollback:	a -> a.rb
							//server:		[a.rb] -> b
							//cl rollback:	a -> [a.rb]
							//client:		a.rb -> b
							if (serverChanges.changes[j].changeType == ChangeType.Rename &&
							clientRollbacks[k].changeType == ChangeType.Rename &&
							serverChanges.changes[j].rFileName == clientRollbacks[k].renamedRFileName) {
								clientRollbacks.RemoveAt(k);
								break;
							}

							//Modifies
							if (serverChanges.changes[j].changeType == ChangeType.Modified &&
							clientRollbacks[k].changeType == ChangeType.Modified &&
							serverChanges.changes[j].rFileName == clientRollbacks[k].rFileName) {
								clientRollbacks.RemoveAt(k);
								break;
							}
						}

						//For Adds, delete whatever the client added, and re-downlaod from server side.
						if (clientChanges.changes[i].changeType == ChangeType.Add) {
							if (debug) Console.WriteLine("FIXREPEAT: Discarded action is an Add, re-downloading file from serverside! " + clientChanges.changes[i].rFileName);
							clientRollbacks.Add(new SyncEvent.Change(clientChanges.changes[i].rFileName, ChangeType.Delete, ""));
							clientRollbacks.Add(new SyncEvent.Change(clientChanges.changes[i].rFileName, ChangeType.Add, ""));
						}

						//Modifies still need to be carried out from server to client.
						if (serverChanges.changes[j].changeType != ChangeType.Modified) serverChanges.changes.RemoveAt(j);
						clientChanges.changes.RemoveAt(i);
						i--;
						//j-- is uneeded, break immediately renders index j useless after this.
						break;
					}
				}
			}
		}

		//Compares current newSyncEvent to a list of existing SyncEvent, and edit newSyncEvent so it dosen't conflict with the existing SyncEvent.
		//Used in AddToServerSyncEvents() and main SyncButton() logic for merging & conflict management
		static void SyncEventConflictResolver(in List<SyncEvent> serverSyncs, ref SyncEvent newSyncEvent) {
			//scan thru all the changes in newSyncEvent.
			// Rules:
			// 1. ADD must not have ANY PRIOR ACTION until the next DELETE on the same file (use filePath as ID). Discard ADD if so, and warn user.
			// 2. RENAME/MODIFIED/DELETE must not have a prior DELETE until the next ADD on the same file (use filePath as ID). Discard RENAME/MODIFIED/DELETE if so, and warn user.

			//if very first additioon, above rules DO NOT apply. Just ensure ALL changes are ADDs. Remove anything else.
			if (newSyncEvent.syncEventNumber == "0") {
				for (int i = 0; i < newSyncEvent.changes.Count; i++) {
					if (newSyncEvent.changes[i].changeType != ChangeType.Add) {
						if (debug) Console.WriteLine("CONFLICTRESOLVER WARNING: Not an ADD change encountered on first sync! Discarding. "
						+ newSyncEvent.changes[i].rFileName + "|" + newSyncEvent.changes[i].changeType);
						newSyncEvent.changes.RemoveAt(i);
						i--;
						continue;
					}
				}
				return;
			}

			//make life easier, store serverSyncs changes AND new changes into one giant list.
			List<SyncEvent.Change> allEvents = new List<SyncEvent.Change>();
			if (debug) {
				Console.WriteLine("=========newSyncEvent===========");
				foreach (SyncEvent.Change ch in newSyncEvent.changes) {
					allEvents.Add(ch);
					Console.WriteLine(ch.rFileName + "|" + ch.changeType + "|" + ch.renamedRFileName);
				}
			}


			for (int i = newSyncEvent.changes.Count - 1; i >= 0; i--) {
				int allEventsIndex = i + (allEvents.Count - newSyncEvent.changes.Count); //magic number. Index coresponds to newSyncEvent index.
				if (ScanForAction(newSyncEvent.changes[i].changeType, allEventsIndex, allEvents)) {
					//VIOLATION FOUND. Remove this entry.
					newSyncEvent.changes.RemoveAt(i);
					allEvents.RemoveAt(allEventsIndex);
					continue; //force continue as the order of indexes have changed.
				}
			}

			//Returns true if violation found, false if nothing found.
			static bool ScanForAction(ChangeType currAction, int allEventsIndex, in List<SyncEvent.Change> allEvents) {

				string currName = allEvents[allEventsIndex].rFileName;

				for (int i = allEventsIndex - 1; i >= 0; i--) {
					//1. 69 -> 69.2
					//2. 69.2 -> 69.3

					//update any potential renames
					if (currName == allEvents[i].renamedRFileName) {
						currName = allEvents[i].rFileName; //every subsequent check uses rFileName now.
					}
					//from this point on, ALWAYS use currName to ID the same files.

					//only allow name matches to pass.
					if (currName != allEvents[i].rFileName) continue;

					if (currAction == ChangeType.Add) {
						// 1. ADD must not have ANY PRIOR ACTION until the next DELETE on the same file (use filePath as ID). Discard ADD if so, and warn user.
						if (allEvents[i].changeType == ChangeType.Delete) {
							return false;
						} else {
							if (debug) Console.WriteLine("CONFLICTRESOLVER WARNING: Adding file that exists (added/renamed/modified) prior! Discarding: " + allEvents[i].rFileName);
							return true;
						}
					} else {
						// 2. RENAME/MODIFIED/DELETE must not have a prior DELETE until the next ADD on the same file (use filePath as ID). Discard RENAME/MODIFIED/DELETE if so, and warn user.
						if (allEvents[i].changeType == ChangeType.Add) {
							return false;
						} else if (allEvents[i].changeType == ChangeType.Delete) {
							if (debug) Console.WriteLine("CONFLICTRESOLVER WARNING: Modifying/Deleting file that is already deleted! Discarding: " + allEvents[i].rFileName);
							return true;
						}
					}
				}
				//if somehow, nothing gets here (idk how), return NO ERROR.
				return false;
			}
		}

		//NOTE: Assumes serverChanges has been appended to syncs, but NOT clientChanges.
		//Fixes a bunch of issues:
		// 1. Renaming the same file to 2 different names (Server rename takes precedence)
		// 2. Renaming 2 files to same name (Server rename takes precedence)
		static void FixClientRenameConflict(ref SyncEvent clientChanges, ref List<SyncEvent.Change> clientRollbacks, ref SyncEvent serverChanges,
		in Dictionary<string, string[]> serverData) {
			//On multiple renames on the same file, GetChangesFromDisk will return something like this:
			//1. server: 69 -> 69server
			//2. client1: 69 -> 69client1 << throw away, silent change: 69client1 -> 69server
			//------------------------------
			//3. server: 69server -> 69server2 
			//4. client2: 69 -> 69server2 << replace 69 with 69server (69server -> 69client2). throw away, silent change: 69server2 -> 69server2

			//======= TURN INTO THIS ==========
			//1. server: 69 -> 69server (silent client: 69client1 -> 69server)
			//------------------------------
			//2. server: 69server -> 69server2 (silent client: 69client2 -> 69server2)

			//On renaming different files into same name, remove the client change and rollback.
			//1. server: ni -> 69a
			//2. client: wo -> 69a

			//======= TURN INTO THIS ==========
			//1. server: ni -> 69a

			// Server rename precedence, client does a silent rollback
			// 1. Check same file -> different name. server precedence, throw away clientChange + rollback client
			// 2. Check different file -> same name. server precedence, throw away clientChange + rollback client

			if (clientChanges == null || clientChanges.changes.Count <= 0) return;

			// 1. check client rename against serverdata and ensure not renaming to existing file.
			// 2. check client file name against serverChanges file name and ensure client does not rename if server is renaming.
			// 3. check client rename against serverChanges and ensure not renaming to same rename in serverChanges.

			for (int i = 0; i < clientChanges.changes.Count; i++) {

				if (clientChanges.changes[i].changeType != ChangeType.Rename) continue;

				// 1. check client rename against serverdata and ensure not renaming to existing file.
				if (serverData.ContainsKey(clientChanges.changes[i].renamedRFileName)) {
					//if it exists, do one more check to see if the offending file is going to be renamed to something else, OR deleted
					//if yes, then allow the change for client.
					//if no, REMOVE this change from clientChange.
					bool allowChange = false;

					//check in clientChange
					foreach (SyncEvent.Change toCheck in clientChanges.changes) {
						// for clientside rename swapping scenario, the changes look abit different:
						// client:	thisFile -> b >> b exists on server!
						//			b -> thisFile
						// hence check if file b is going to be renamed!
						if (clientChanges.changes[i].renamedRFileName == toCheck.rFileName) {
							if (toCheck.changeType == ChangeType.Delete || toCheck.changeType == ChangeType.Rename) {
								allowChange = true;
								break;
							}
						}
					}


					//check in serverChange
					if (!allowChange && serverChanges != null)
						foreach (SyncEvent.Change toCheck in serverChanges.changes) {
							if (clientChanges.changes[i].rFileName == toCheck.rFileName) {
								if (toCheck.changeType == ChangeType.Delete || toCheck.changeType == ChangeType.Rename) {
									allowChange = true;
									break;
								}
							}
						}


					if (!allowChange) {
						//REMOVE from clientchange
						if (debug) Console.WriteLine("FixRename: This client file is going to be renamed to an existing file on the server. Rolling back rename for clientChanges." +
						"\n\tClient File Name: " + clientChanges.changes[i].rFileName + "\n\tRenamed File Name: " + clientChanges.changes[i].renamedRFileName);
						//Add it to clientRollback. Rename the file back to its original name according to client .data
						clientRollbacks.Add(new SyncEvent.Change(clientChanges.changes[i].renamedRFileName, ChangeType.Rename, clientChanges.changes[i].rFileName));
						//Remove the entry from clientChange
						clientChanges.changes.RemoveAt(i);
						i--;
						continue; //i--, immediately move to next item before doing more logic.
					}
				}

				// 2. check client file name against serverChanges file name and ensure client does not rename if server is renaming.
				// 3. check client rename against serverChanges and ensure not renaming to same rename in serverChanges.
				if (serverChanges != null) {
					bool skip = false;
					foreach (SyncEvent.Change serverChange in serverChanges.changes) {

						if (serverChange.changeType != ChangeType.Rename) continue;
						// 2. check client file name against serverChanges file name and ensure client does not rename if server is renaming.
						//if both are rename and are the same name e.g.
						//1. server: 69 -> eh1 (69.rb -> eh1)
						//2. client: 69 -> eh2

						//serverChange.rFileName has a .rb because serverChanges is run through FixRenameSwapScenario previously. Remove it and all is well.
						if (serverChange.rFileName.Replace(".rb","") == clientChanges.changes[i].rFileName) {
							//REMOVE from clientchange
							Console.WriteLine("FixRename: This client file has been already renamed by the server. Rolling back rename for clientChanges" +
							"\n\tClient File Name: " + clientChanges.changes[i].rFileName + "\n\tRenamed File Name: " + clientChanges.changes[i].renamedRFileName);
							//Add it to clientRollback. Rename the file back to its original name according to client .data
							//add a .rb at the end of client filename, as this scenario will only happen in this specific setting. The renaming process would require .rb.
							clientRollbacks.Add(new SyncEvent.Change(clientChanges.changes[i].renamedRFileName, ChangeType.Rename, clientChanges.changes[i].rFileName + ".rb"));
							//Remove the entry from clientChange
							clientChanges.changes.RemoveAt(i);
							i--;
							skip = true;
							break; //i--, immediately move to next item before doing more logic.
						}

						// 3. check client rename against serverChanges and ensure not renaming to same rename in serverChanges.
						//if both are rename and renaming to SAME name e.g.
						//1. server: 123 -> eh
						//2. client: 456 -> eh
						if (serverChange.renamedRFileName == clientChanges.changes[i].renamedRFileName) {
							//REMOVE from clientchange
							Console.WriteLine("FixRename: There is a server name change that has the same rename as this client file. Rolling back rename for clientChanges." +
							"\n\tClient File Name: " + clientChanges.changes[i].rFileName + "\n\tRenamed File Name: " + clientChanges.changes[i].renamedRFileName);
							//Add it to clientRollback. Rename the file back to its original name according to client .data
							clientRollbacks.Add(new SyncEvent.Change(clientChanges.changes[i].renamedRFileName, ChangeType.Rename, clientChanges.changes[i].rFileName));
							//Remove the entry from clientChange
							clientChanges.changes.RemoveAt(i);
							i--;
							skip = true;
							break; //i--, immediately move to next item before doing more logic.
						}
					}
					if (skip) continue;
				}
			}
		}

		//Changes the way renames are handled, so renames won't interfere with each other when swapping names. Temporarily appends a .rb to the end of a rename
		static void FixRenameSwapScenario(ref SyncEvent changes, ref List<SyncEvent.Change> rollbacks) {
			//rollback structure: 
			//rollback:	x.mp3 -> x.mp3.rb
			//			x.mp3.rb -> y.mp3

			//change all rename targets into .rb under rollback (x.mp3 -> x.mp3.rb)
			//Then set the final rename to use .rb under changes (x.mp3.rb -> y.mp3)
			for (int i = 0; i < changes.changes.Count; i++) {
				if (changes.changes[i].changeType != ChangeType.Rename) continue;

				//SyncEventConflictResolver and FixClientRenameConflict have been done (if any).
				//rename rollbacks have been added to the clientRollback list, and offending renames have ben removed from clientChanges so no worries.

				rollbacks.Add(new SyncEvent.Change(changes.changes[i].rFileName,ChangeType.Rename, changes.changes[i].rFileName + ".rb"));
				changes.ChangeFileName(i, changes.changes[i].rFileName + ".rb");
			}
		}
		#endregion
		
		//Adds a new SyncEvent to serverSyncs, after performing parity checks with the rest of the data in serverSyncs.
		static void AddToServerSyncEvents(ref List<SyncEvent> serverSyncs, ref SyncEvent newSyncEvent) {

			if (newSyncEvent == null || newSyncEvent.changes.Count == 0) return;

			Console.WriteLine("Removing .rb extensions from renamed files before adding to serverSyncs");
			//clear serverSyncs from having .rb extension during rename.
			SyncEvent newnewSyncEvent = new SyncEvent(newSyncEvent); //create a new copy or else serverSyncs will have a reference to the original newSyncEvent
			for (int i = 0; i < newnewSyncEvent.changes.Count; i++) {
				if (newnewSyncEvent.changes[i].changeType != ChangeType.Rename) continue;
				newnewSyncEvent.ChangeFileName(i, newnewSyncEvent.changes[i].rFileName.Replace(".rb", ""));
			}

			Console.WriteLine("Adding a new SyncEvent entry!");
			serverSyncs.Add(newnewSyncEvent);
			globalNextSENumber++;

			if (debug) {
				Console.WriteLine("========== Current serverSyncs =============");
				foreach (SyncEvent r in serverSyncs) {
					Console.WriteLine("SyncNumber: " + r.syncEventNumber + "|Machine: " + r.machineID + "|Time: " + r.timeStamp + "|Count: " + r.changes.Count);
					foreach (SyncEvent.Change c in r.changes) {
						Console.WriteLine(c.rFileName + "|" + c.changeType + "|" + c.renamedRFileName);
					}
					Console.WriteLine("--------------------------------------------");
				}
			}

		}

		#region Writing save data to disk helpers
		//Perform a singular File IO Operation, from sourceFolder to targetFolder.
		//sourceFolder is ignored for IO that only happens on targetFolder.
		//Do a second round of .data updating as FileIO actions are being performed!
		static void PerformFileIO(string hostFolder, string targetFolder, SyncEvent.Change change, ref Dictionary<string, string[]> targetData) {
			// On ADD, copy file to target, add new .data entry
			// On DELETE, remove file from target, remove .data entry
			// On RENAME, rename file at target, update fileName in .data entry
			// On MODIFIED, copy & replace file to target, update LocalId

			Console.WriteLine("Performing: " + change.rFileName + ", " + change.changeType + " " + change.renamedRFileName);

			string hostFile = Path.Join(hostFolder, change.rFileName);
			string destFile = Path.Join(targetFolder, change.rFileName);
			string destDir = Path.GetDirectoryName(destFile);

			switch (change.changeType) {
				case ChangeType.Add:
					//Check if source file exists
					if (!File.Exists(hostFile)) {
						Console.WriteLine("ERROR: On add: File not found - " + hostFile);
						break;
					}

					//Check if destination file exists
					if (File.Exists(destFile)) {
						Console.WriteLine("Warning: File exists! Skipping. " + hostFile);
						break;
					}

					//Create dir
					Directory.CreateDirectory(destDir);

					//Copy file
					try {
						File.Copy(hostFile, destFile, false);
					} catch (Exception e) {
						Console.WriteLine("Error copying file: " + hostFile + "\nError Msg: " + e.Message);
						break;
					}

					//add new .data entry to data
					if (!targetData.ContainsKey(change.rFileName)) {
						targetData.Add(change.rFileName, new string[] { GetUniqueFileID(destFile), File.GetLastWriteTime(destFile).ToString("yyyyMMddHHmmss") });
					} else {
						Console.WriteLine("WARNING: Could not add new entry to .data, entry already exists: " + change.rFileName + "\n.data File: " + targetFolder);
						targetData[change.rFileName] = new string[] { GetUniqueFileID(destFile), File.GetLastWriteTime(destFile).ToString("yyyyMMddHHmmss") };
					}
					break;

				case ChangeType.Delete:
					//Check if target file exists
					if (!File.Exists(destFile)) {
						Console.WriteLine("ERROR: On delete: File not found - " + destFile);
						break;
					}

					//Delete file
					try {
						File.Delete(destFile);
					} catch (Exception e) {
						Console.WriteLine("Error deleting file: " + destFile + "\nError Msg: " + e.Message);
						break;
					}
					//remove .data entry to data
					if (targetData.ContainsKey(change.rFileName)) {
						targetData.Remove(change.rFileName);
					} else {
						Console.WriteLine("ERROR: Could not delete entry in .data, entry not found: " + change.rFileName + "\n.data File: " + targetFolder);
					}
					break;

				case ChangeType.Rename:
					//Check if target file exists
					if (!File.Exists(destFile)) {
						Console.WriteLine("ERROR: On rename: File not found - " + destFile);
						break;
					}

					//rename file
					string targetFile = Path.Join(targetFolder, change.renamedRFileName);

					if (!File.Exists(targetFile)) {
						try {
							File.Move(destFile, targetFile);
						} catch (Exception e) {
							Console.WriteLine("Error renaming file: " + destFile + "\nError Msg: " + e.Message);
							break;
						}
						// update .data entry
						if (targetData.ContainsKey(change.rFileName)) {
							targetData.Add(change.renamedRFileName, targetData[change.rFileName]);
							targetData.Remove(change.rFileName);
						} else {
							Console.WriteLine("ERROR: Could not edit entry in .data, entry not found: " + change.rFileName + "\n.data File: " + targetFolder);
						}
					} else {
						// if target name to move to alr exists, append a number to the name of the file.
						Console.WriteLine("Warning on Rename: File alr exists in target directory, appending a seperate name: " + targetFile);
						int availNum = 1;
						string fileExt = Path.GetExtension(targetFile);
						string fileNameNoExt = Path.GetFileNameWithoutExtension(targetFile);
						string parentDir = Directory.GetParent(targetFile).FullName;
						string newFileName = Path.Join(parentDir, fileNameNoExt) + " (" + availNum + ")" + fileExt;
						while (File.Exists(newFileName)) {
							availNum++;
							newFileName = Path.Join(parentDir, fileNameNoExt) + " (" + availNum + ")." + fileExt;
						}
						try {
							File.Move(destFile, newFileName);
						} catch (Exception e) {
							Console.WriteLine("Error renaming file: " + destFile + "\nError Msg: " + e.Message);
							break;
						}
						// update .data entry
						string relativeFileName = newFileName.Replace(targetFolder,"");
						if (targetData.ContainsKey(relativeFileName)) {
							targetData.Add(relativeFileName, targetData[change.rFileName]);
							targetData.Remove(change.rFileName);
						} else {
							Console.WriteLine("ERROR: Could not edit entry in .data, entry not found: " + change.rFileName + "\n.data File: " + targetFolder);
						}
					}
					break;

				case ChangeType.Modified:
					//Check if source file exists
					if (!File.Exists(hostFile)) {
						Console.WriteLine("ERROR: On modify: File not found - " + hostFile);
						break;
					}

					//Copy file
					try {
						File.Copy(hostFile, destFile, true);
					} catch (Exception e) {
						Console.WriteLine("Error copying(modify) file: " + hostFile + "\nError Msg: " + e.Message);
						break;
					}
					//update .data entry to data
					if (targetData.ContainsKey(change.rFileName)) {
						targetData[change.rFileName][0] = GetUniqueFileID(destFile);
					} else {
						Console.WriteLine("ERROR: Could not edit entry in .data, entry not found: " + change.rFileName + "\n.data File: " + targetFolder);
					}
					break;
			}

		}

		//Writes a new sync file to disk. Accepts null sync file. Used to write client .sync
		static void WriteSyncFile(string path, in List<SyncEvent> syncs, int nextSENumber, string serverDateVersionNumber) {
			Directory.CreateDirectory(path);
			using (StreamWriter sw = File.CreateText(Path.Join(path, ".sync"))) {
				sw.WriteLine("1.0 Sync File|" + serverDateVersionNumber);
				sw.WriteLine("");
				sw.WriteLine(nextSENumber); //Next sync number

				if (syncs != null) {
					foreach (SyncEvent ev in syncs) {
						sw.WriteLine("#" + ev.syncEventNumber + "|" + ev.machineID + "|" + ev.timeStamp);
						foreach (SyncEvent.Change chng in ev.changes) {
							sw.WriteLine(chng.rFileName + "|" + chng.changeType + "|" + chng.renamedRFileName);
						}
					}
				}
			}
		}

		//Writes a new data file to disk.
		static void WriteDataFile(string path, in Dictionary<string, string[]> data) {
			Directory.CreateDirectory(path);
			using (StreamWriter sw = File.CreateText(Path.Join(path, ".data"))) {
				sw.WriteLine("#1.0 Data File");
				sw.WriteLine(path);
				sw.WriteLine("");

				if (data != null && data.Count > 0) {
					foreach (KeyValuePair<string, string[]> item in data) {
						sw.WriteLine(item.Key + "|" + item.Value[0] + "|" + item.Value[1]);
					}
				}
			}
		}
		#endregion

		#region misc helpers
		//searches the entire dict to find the entry that has the matching localId. returns "" if not found.
		//hella inefficient but i can't be arsed to restructure my entire dictionary structure to have localId as the key. I'm in too deep. 
		static string FindKeyInDataDict(string localId, in Dictionary<string, string[]> dict) {
			foreach (KeyValuePair<string, string[]> entry in dict) {
				if (entry.Value[0] == localId) {
					return entry.Key;
				}
			}
			return "";
		}

		//Takes a file extension. period dosen't matter.
		static bool IsMusicFileExtension(string ext) {
			if (ext.Length > 0 && ext[0] == '.') {
				ext = ext.Remove(0, 1);
			}

			ext = ext.ToUpper();

			switch (ext) {
				case "3GP":
				case "AA":
				case "AAX":
				case "ACT":
				case "AIFF":
				case "ALAC":
				case "AMR":
				case "APE":
				case "AU":
				case "AWB":
				case "DSS":
				case "DVF":
				case "FLAC":
				case "GSM":
				case "M4A":
				case "M4B":
				case "M4P":
				case "MMF":
				case "MIDI":
				case "MP1":
				case "MP2":
				case "MP3":
				case "MP4":
				case "MPC":
				case "OGG":
				case "OGA":
				case "MOGG":
				case "RAW":
				case "RF64":
				case "TTA":
				case "WAV":
				case "WEBM":
				case "CDA":
				case "OPUS":
				case "VIDEO":
				case "WINAMP":
				case "WMA":
				case "WV":
					return true;
				default:
					return false;
			}
		}

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

#pragma warning disable CS0618 // Type or member is obsolete
			GetFileInformationByHandle(fs.Handle, out objectFileInfo);
#pragma warning restore CS0618 // Type or member is obsolete

			fs.Close();

			ulong fileIndex = ((ulong)objectFileInfo.FileIndexHigh << 32) + (ulong)objectFileInfo.FileIndexLow;

			return fileIndex.ToString();

		}
		#endregion
		#endregion
	}
}
