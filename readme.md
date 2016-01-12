Buttonica: Realms of Color
==========================

This is the official development repository of the *Buttonica* project, a strategic hack 'n' slash 
roleplaying adventure based on the various legends and religions that emerged around reddits 
[/r/thebutton](https://reddit.com/r/thebutton). Influenced by a variety of genres, *Buttonica: Realms of Color*
not only aims to provide an unusual and unique gaming experience, but also tries to keep the spirit of
[/r/thebutton](https://reddit.com/r/thebutton) alive. Many gameplay concepts derive directly from the core ideas
of [/r/thebutton](https://reddit.com/r/thebutton), others are based on the imagination and randomness of hundreds
of thousands redditors that participated in one of the most confusing social experiments ever applied to humanity. :smile:

For more information about *Buttonica: Realms of Color*, head over to the [Buttonica Wiki](https://github.com/artganify/buttonica/wiki)
(*incomplete*). For discussions, ideas and general interaction with the community, check out
[/r/buttonica](https://reddit.com/r/buttonica): [https://reddit.com/r/buttonica](https://reddit.com/r/buttonica).

## Building the source

### Requirements

* **Visual Studio 2015** or [Visual Studio 2015 Community](https://www.visualstudio.com/products/visual-studio-community-vs) (free).
  *MonoDevelop* should work too (untested!)
* **Nuget**, ships with Visual Studio, can alternatively be obtained through [Chocolatey](https://chocolatey.org/)
* **.NET 4.5** or above (or *Mono*)
* **Monogame**, will be retrieved using *nuget*
* **git**
* **git lfs**, used for large binary assets, see here: [https://git-lfs.github.com/](https://git-lfs.github.com/) 
  ([What if I don't have git lfs?](https://help.github.com/articles/collaboration-with-git-large-file-storage/))

### Obtaining the source code

Fire up your favorite git client (GitHub Desktop, SourceTree) or the git command line and

    git clone git://github.com/artganify/buttonica.git

### Restoring dependencies

You need to restore Nuget packages. The easiest way is to open up Visual Studio or MonoDevelop and simply restore
all packages using their built-in tools. Alternatively, you can restore packages using the command line:

    # default
    nuget restore

    # mono
    mono path/to/nuget.exe restore

### Compiling

Just compile the source using Visual Studio or MonoDevelop.

## Getting involved

We are always looking for cool people to work with, whether you are a developer, artist, musician or whatever.
"Job advertisements" are usually posted on the [/r/buttonica](https://www.reddit.com/r/Buttonica/) subreddit or
on [/r/buttonica_dev](https://www.reddit.com/r/buttonica_dev). If you like to apply for something, just message
the mods and we'll get in touch with you.

For developers: Just fork the source here on github, apply your contribution / modification and create
a pull request so we can look into it. :)