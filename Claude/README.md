# Claude

## Claude 200 Useful prompts : https://special-tamarind-9e9.notion.site/200-Claude-Prompts-846ccdb23d99835095c3011d10a89e01

## Claude 20+ Skills : https://special-tamarind-9e9.notion.site/Claude-Masterclass-20-Skills-Templates-312ccdb23d9980e59d95eb1f9ab9695b

## Web Search VS Web Scraping search

- If we asked Claude to search only web for a particular data it will return minimal data, in the other hand, if we use any web scraping tool inside Claude it will return many more data.
- Best tool for Web Scraping is **Apify**.

## Claude Cowork

- Describe any task. Cowork manages your files, write reports, does research and automates workflows right on your computer

### Task 1 : Folder Arrangement
- Lets assume we have a folder and have expense data date wise but file name is not contains date. So we can ask Claude to rename all the files with Date in the format MMDDYYY at the beginning for the file name
		- Claude will rename all the file by reading its content
- Ask Claude to create sub folders Month wise and move relevant files to that folder and give me a report about the file and folder details
	- Claude will Create sub folder and arrange files and give me the report.


### Task 2: Make short video from a large video

- Drop the source video and type the following prompt
	- Please create 10 second time lapse video from this material, showing the most important parts

 ### Task 3 : Create expense report 
- I have many receipts in the folder I gave you access to. Please create a expense spreadsheet in the .CSV format with appropriate columns and fulfill the data from the screenshots. (Receipts may be in Jpg or png or any formats

### Task 4 :  Create a presentation
<img width="1056" height="661" alt="image" src="https://github.com/user-attachments/assets/bb834d61-4ee9-4dc3-9ef1-70e68ce83e8f" />


### Task 5 : Performing Tasks in Browser
- Download Claude extension in Browser
- Login to Claude account
- Now two ways we can interact with Calude from Browser
	- In side claude extension in the browser
	-  Once Claude extension enable, we can instruct Open Browser and search for something
			- Open for me "X" in the browser and search for news about Claude Cowork
	- We can ask Clade to open my Github, create a repository and write a file on it.
	- We can ask Claude Cowork to create a react app and uploaded to Github repo and deploy it in Github
	- Please goto youtube and type inside "Ai agent tutorial"


### Task 6 : Using Chrome Claude extension to schedule task
	- Open Claude extension in Chrome browser
	- Clieck Tech Claude button
	- Enable Microphone
	- Record a message, "Open my googel document and search for a document name xxx, Open that document and read all the content and create a downloadable word document"
	-  Now correct generated prompt as our target.
	- In teh Start from box we can give the document path in google doc.
	- *** We can also ask to generate image using open Chtgpt, click download and add it to the document etc...
	- Give a name to this shortcut prompt
	- If you want to use this shortcut, type / and select the shortcut from the popup list
	- Once verify it is working fine click on the Claude extension vertical ...
	- Select Settings,
	- On Lefthand menu select Shortcuts
	- You can see all the Shortcut we created
	- By selecting a Shortcut ... we can shedule this shortcut as repeating Task
	
	- ***** We can do it to Gmail, Read last 5 unread email .......

### While instructing the Claude, do the same operations step by step so Claude will learn it from our action


### Connectors
- It is a Claude way of connecting applications
	- Ex. Gmail, Slack, Teams etc.
- Under Customize Menu we have Connectors
- Connection has two Add Connter options
		- Browse Connectors (Applications)
		- Add Custom Connectors (MCP Server)

- Connecting MCP Server
	- Github Bright Data
	- https://github.com/brightdata     /   https://github.com/brightdata/brightdata-mcp
	- Goto **Setup in Claude Desktop:**
	- Connect Claude as per the document
		- Name : Bright Data Web
		- URL : https://mcp.brightdata.com/mcp?token=YOUR_API_TOKEN
		- Take Token from https://brightdata.com/cp/mcp   (Need registration)
		- Click on Connect

### Claude Dispatch
- Claude Computer Use
- Connect our computer from remote 
- Three Mode
	- Full Control
	- View Only
	- Blocked

<img width="1532" height="710" alt="image" src="https://github.com/user-attachments/assets/c9a0af8d-615c-4d35-8507-bec6077e38f3" />


<b>How to Enable Access Computer in Claude</b> <br/>
	- Go to Setting by selecting your profile <br/>
	- Got to **General tab** ( May have two general tabs) <br/>
	- Locate Computer use <br/>
	- Enable it, also if you want to Denied some app, we can select those app in the Denied App section <br/>
	- Now We can give prompt to use it <br/>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	- ex. Please use the computer use. Open for me screen studio folder, and then open the last video recorded. Export it for me in 720p quality. <br/>
	- We can ask any application to open and do some operation. ex. Facebook, word, PPT. Claude will take control of the computer so we need to be ideal until Claude finishes its work <br/>


	  
