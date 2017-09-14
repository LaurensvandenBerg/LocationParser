# LocationParser
Reading Location history files provided by google.

# Installation

*Will be improved in the future*
1. Clone the code from github.
2. Open a command line tool and navigate to the root of the project.
3. Run {dotnet build}.
4. Navigate to the location of the .exe file which was created by the build.

# Getting Started

1. Head over to https://takeout.google.com/settings/takeout.
2. Select the Location history option in JSON format.
3. Choose a preffered Delivery method (easiest is to send download link via email).
4. While waiting for the archive to be ready, get some tea
5. Download the archive, if asked for it, log in with the same google account as the timeline is registered with.
6. Unzip the archive and go to Takout/Location History.
7. Open a command line tool {make sure it's still in the folder where the application was installed}.
8. Run "Locationparser.exe read {path/to/Location History.json}".

# Commands:
 
## LocationParser [options] [command]

### Options:
  -h|--help|{no argument}  Show help information

### Commands:
  filter: Remove all Timeline entries which do not match the given filter
  open:   Open a previously saved file
  read:   Read a new Location history file
  save:   Save the current working TimeLine to with a specified name

## Filter [options] [command]

### Options:
  -h|--help|{no argument}  Show help information

### Commands:
  daterange: Select all entries between 2 given dates, given in format: DD-MM-YYYY

## Open [arguments] [options]

### Arguments:
  {no argument}: List of files which can be opened.
  name:          The name of the file to be opened.

### Options:
  -h|--help  Show help information

## Read [arguments] [options]

### Arguments:
  path: The path of the JSON file with the locations.

### Options:
  -h|--help|{no argument}: Show help information

## Save [arguments] [options]

### Arguments:
  name: The name of the TimeLine
  path: optional path of the TimeLine

### Options:
  -h|--help{no argument}: Show help information