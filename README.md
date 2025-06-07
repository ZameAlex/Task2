# Run
To run the app, you should have installet .net8.0
The repository contains only code, so you should build it.
The loading and processing data will be done automatically after run the app.
# Comments
Several fields from users and posts should be marked as nullable, but the data doesn;t have such examples, so I ignored it.
Code contains 2 filter. First will show all the users with cities names starts with "S" in the format, proposed int the task description:
    Name: Leanne Graham
    City: South Christy
    Posts count: 5
The second one shows users with more than half of their posts with title more than 40 letters. The count shows the number of posts where the body contains more than 170 letters. The format is the same.