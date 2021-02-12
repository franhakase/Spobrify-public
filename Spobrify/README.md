**Spobrify**

 - [Description](#desc)
- [Features](#feat)
- [Installation](#install)
- [Credits/Special thanks](#thank)
- [Contributing](#contr)

```
### My Great Heading {#desc}
```
**Spobrify** is a C# application to listen(audio only) to `Youtube.com` videos. It supports most Youtube videos and is capable of loading and saving playlists for your convenience.
It works by parsing the Youtube web page content and extracting the audio stream, which saves bandwitdth and allows quick content loading.

![Main screen](https://i.imgur.com/Es2O72V.png)

![Search](https://i.imgur.com/SqGmMEC.png)
![Overlay window (for live streaming software)](https://i.imgur.com/DmuHjkG.png)

```
### Features {#feat}
```

- Video search;
- Playlist search;
- Song name overlay window (for use with OBS and other live streaming software);
- Playlist loading and saving in a custom text format;
- Play/Pause, Forward/Next, Volume and Shuffle;
- Lightweight (uses ~36 MB on my computer) 
- Loads only the audio URL (saves bandwith);

```
### Instalation {#inst}
```
Simply extract the provided **.zip** file and run **Spobrify.exe** or download the source and compile it using a recent Visual Studio version (versions tested: 2015, 2017, 2019).

```
### Credits/Special Thanks {#thank}
```
- The fine people over at **youtube-dl**;
- JWT, for his [fabulous Youtube downloader](https://www.jwz.org/hacks/youtubedown);
- [This gist by Emzi0767](https://gist.github.com/Emzi0767/9248b935e5cca78c5b81111f9c2ea4d8), which inspired me to start this project.
