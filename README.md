*ExpressProfiler* (aka *SqlExpress Profiler*) is a simple and fast replacement for SQL Server Profiler with basic GUI and integration with Red Gate Ecosystem project.

Can be used with both Express and non-Express editions of SQL Server 2005/2008/2008r2/2012/2014 (including LocalDB)
Distribution package contains both standalone version of ExpressProfiler (can be used without installation) and installation package.

*Breaking news!* ExpressProfiler is now part of  Red Gate ecosystem project ([url:http://documentation.red-gate.com/display/MA/SSMS+ecosystem+project])! (framework is not included in installation package and should be downloaded and installed manually).
If you don't have SIPF framework then installation package simply installs ExpressProfiler.
Both standalone ExpressProfiler application and Ecosystem installer are digitally signed.

*Features*
* Tracing of basic set of events (Batch/RPC/SP:Stmt Starting/Completed, Audit login/logout, User error messages, Blocked Process report) and columns (Event Class, Text Data,Login, CPU, Reads, Writes, Duration, SPID, Start/End time, Database/Object/Application name) - both selectable
* Filters on most data columns
* Copy all/selected event rows to clipboard in form of XML 
* Find in "Text data" column
* Export data in Excel's clipboard format

*Did you know?*
You can filter your trace
[image:filter1.png]
[image:filter2.png]

*Command-line parameters.* 
Can be used to set default GUI values
* -server, -s  <server name>
* -user, -u  <user name>
* -password, -p <user password>
* -maxevents, -m <value> : set maximum events in event list (1000 by default)
* -duration, -d <min duration> : sets filter on duration column
* -start  :  automatically start profiling

*Plans/Roadmap*
* online query normalization
* online extraction of actual query from prepared statements/sp_executesql
* online execution statistics grouped by normalized statements
* save/load captured trace



