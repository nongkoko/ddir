# 🗂️ ddir — A Smarter Way to List Files
**ddir** (short for **D-Dir**, inspired by “D-Day”) is a modern, extensible CLI tool that redefines how you interact with your filesystem. Built as a one-page logic powerhouse, `ddir` offers recursive file and directory listing with dynamic formatting, pattern filtering, and customizable output—all in a single, elegant command.
Whether you're auditing files, scripting automation, or just want a smarter `dir`, `ddir` gives you:
## ✨ Key Features
- 🔍 **Pattern-based filtering** (`pattern`)  
&nbsp; Filter files and directories using flexible pattern matching.
- 📁 **Recursive traversal** (`deep`)  
&nbsp; Traverse nested directories with ease.
- 🎨 **Custom output formatting** (`format`)  
&nbsp; Tailor the output to match your workflow or script requirements.
- 🎀 **Prefix/suffix decoration** (`prefix`, `suffix`)  
&nbsp; Add context or visual cues to your listings.
- 🧾 **Header injection** (`header`)  
&nbsp; Insert headers for better readability or documentation.
- 🔢 **Output limiting** (`limit`)  
&nbsp; Control the number of results returned.
- 📄 **File name isolation** (`fileNameOnly`)  
&nbsp; Extract and display only the file names.

**ddir** is a lean, purpose-built alternative to dir, engineered for developers and power users who demand speed, control, and memory efficiency.
When the `--limit` option is enabled, ddir switches to a low-level `FindFirstFile` traversal mode — tracing files one by one instead of bulk-fetching the entire directory. This means faster execution, lower memory footprint, and precise control over what gets scanned.

---
command parsing and designed with modularity in mind, `ddir` is perfect for:
- Developers  
- Sysadmins  
- Automation enthusiasts  
If you demand **clarity**, **control**, and **customization**, `ddir` delivers it—all in one command.