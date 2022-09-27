# Proforientir
Software package for monitoring the career guidance work of the university department
## Software package functionality
- Collection and evaluation of information on the number of enrolled students for time periods and average scores.
- Tracking student activity.
- Collection and storage of information about the topic and results of career guidance and scientific events.
- Collection and evaluation of information about the current situation of graduates.
- Assessment of the prospects of students when choosing a job in the direction of the department (assessment of the current situation in the labor market).
- Compilation of reports and statistics of monitoring results.
## Building and running the project
The software package was developed for use in a local network.
### Server
Import from the "ServerProforientir" folder the ```career_guidance.sql``` file containing the database of the software package. Then run the ```index.php``` file on the server.
### PC
Before running the application, find the ```units.txt``` file in the "Proforientir" project folder. In the ```units.txt file```, enter the address of the host where the server is deployed as the first line.The next lines of the file are the name (2nd line) and password (3rd line) of the database user.

Some features require an internet connection.

To perform some functions, a user with an "administrator" access type will also need to move the contents of the "www" folder to the root folder of the computer's host. 
Next, find the ```path.txt``` file in the "Proforientir" folder and enter the path to the folder where the files from "www" were transferred.
## Using the software package
By default, an account with access type "administrator" is registered in the system with login: ```admin```, password: ```1234```. After the authorization, a button for editing personal data is available, where you can change the default values.

At the time of development of the software package in 2020, the new Google privacy policy of 2022 has not yet entered into force, which prohibits access to applications that have not passed OAuth authentication. Therefore, some functions of the software package may not be available.
### Administrator access type
- To add information about a new student, Internet access is required, since enrollment orders are downloaded from the university website.
- To edit materials for ongoing career guidance events, Internet access is required, since the files for career guidance events are stored on the GoogleDrive of the Proforientir system.
- To view the results of the student survey, you need access to the Internet and prior authorization in the Google Drive of the Proforientir system.
- Internet access is required to update information on the labor market, as data is collected from open job sites.
- The "administrator" has the opportunity to register employees of the department with the access type "employee" by default, while you must specify the full name and mail. An invitation with a one-time code is sent to the specified mail of the employee, with which he completes the registration process on his own, namely, he indicates the login and password. Subsequently, the "administrator" can increase or decrease the access rights of an employee. The registration of a student is similar, however, the initiator can be not only an "administrator", but also an employee of the department.



