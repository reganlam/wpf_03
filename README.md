# wpf_03

To seperate code from the view, we need to create view models.

Create a new folder called "Directory" to contain our data

Create a class DirectoryItem
	- Name of item
	- Type of item (file, folder, drive)
	- Full path to item

Remove brute force "Window_Loaded" that retrieves our drives
	- Instead create a method that retrieves our drives within DirectoryStructure

Remove brute force "Folder_Expanded" that retrieves all folders/files in a directory
	- Instead create a method that retrives all the contents within a directory in DirectoryStructure

Once we have our classes and methods set up, we can create our view models to link the UI with our Data

To implement a viewmodel we need
	- implement the interface INotifyPropertyChanged for a viewmodel class
	- Install a package called Fody ProperyChanged to help us make it easier to implement PropertyChanged
		- Allows us to not have to explicity write get / set for each property we want changed

