# GistIdeInformation 
MonoDevelop/Xamarin Studio addin to create a gist of the the Ide log and information.

## Install
Use the addin manager in MonoDevelop/Xamarin Studio to install.

## Configure
Once installed, the commands will not be available until you set your GitHub username and PAT.

The PAT is used to authenticate against the Gist API. To create the PAT follow [this doc](https://help.github.com/articles/creating-an-access-token-for-command-line-use/#creating-a-token). Make sure the Gist permission is selected.  
Go to MonoDevelop/Xamarin Studio preference and look for "Gist User Information", enter it, and save.

Now, under the Help menu you should see the commands available.  
"Create About Gist" will create and open the gist in a browswer. "Create and Copy About Gist" will create the gist and only copy it to your clipboard!
