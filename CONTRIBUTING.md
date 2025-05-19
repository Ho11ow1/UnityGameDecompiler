# Contributing

If you think you could add or improve something within the project, or if you want to become a contributer feel free to try,<br/>
All contributions are greatly appreciated.


## How to

##### 1. Fork the repository
```bash
# Click the Fork button (located in the top-right corner of the page)
```

##### 2. Clone the repository
```bash
git clone https://github.com/Ho11ow1/UnityGameDecompiler
```

##### 3. Create a new branch
```bash
git checkout -b your-branch-name
```

##### 4. Make, stage, commit and push your changes
```bash
# Stage your changes
git add .
```
```bash
# Commit your changes with the commit message style below
git commit -m "Describe the changes you made"
```
```bash
# Push your changes to your forked repository
git push origin your-branch-name
```

##### 5. Submit a pull request
```bash
# On your forked repository on GitHub you should see a prompt to Compare & Pull Request.
# Provide a clear description of what you’ve done and why it’s useful.
# Click Create Pull Request.
```


## Contributing guidelines and style

##### 1. Code style
- Indent size: Use 4 spaces
- Variable names: Clear, easy to understand
- Brackets: Always on a new line, with the following exceptions:
  - Lambda functions
  - A quick `if` statement: Brackets remain on the same line seperated by a space. Example: 
  ```bash
  if (condition) { return; }
  ```
- Using statements: Encapsulated in () to close at the end of the statement not the function

##### 2. Commit messages(Not that important but good for consistancy)
- Title: A concise but descriptive title
- Description: A more in-depth description(if necessary)