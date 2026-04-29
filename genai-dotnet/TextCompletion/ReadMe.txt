- Install 
	* Microsoft.Extensions.AI
	* Microsoft.Extensions.AI.OpenAI   - Use to communicate with Azure OpenAI or OpenAI Models
	* Microsoft.Extensions.Configuration
	* Microsoft.Extensions.Configuration.UserSecrets

- Right click the project and select "Manage User Secrets". This will open a secrets.json file 
	where you can add your API keys and other sensitive information.
	- Add the following configuration to the secrets.json file:
		{
			"GitHubModels:Token": "<Token here>"
		}
