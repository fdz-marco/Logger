# Logger

This application is to test a simple log class (static) for bigger projects.

Use:
- Copy all the content of the folder Classes in your project.
- Add a reference of the namespace in your project: `using glitcher.core.Logger;`
- Where is needed call the static method to add the message to the logger:
```cs
Logger.Add(LogLevel.Error, "Group", "Message", "Whisper (Extra information)");
```

Is possible to call the **Log Viewer** from any place on project using also next line:
```cs
LogViewer.GetInstance().Show();
```

---

### Screenshot of the Log Viewer itselt
![Logger](readme_img_logger.png?raw=true "Logger")

---

### Screenshot of the Logger Tester Form
![Logger Tester](readme_img_loggertester.png?raw=true "Logger Tester")

---