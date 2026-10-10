# RatioMaster
[![Release](https://img.shields.io/github/v/release/sergiye/RatioMaster)](https://github.com/sergiye/RatioMaster/releases/latest)
![Downloads](https://img.shields.io/github/downloads/sergiye/RatioMaster/total?color=ff4f42)
![Last commit](https://img.shields.io/github/last-commit/sergiye/RatioMaster?color=00AD00)

## About

RatioMaster is a small standalone Windows application that fakes the upload and download statistics of a torrent for almost any BitTorrent tracker.

It does **not** depend on your BitTorrent client (uTorrent, Azureus, BitComet, ABC, etc.) and it does **not** download or upload any real data: it only reports the numbers you choose to the tracker, the way a real client would.

## Features

### Torrents and trackers
- Open a `.torrent` file with the **Browse...** button or drag and drop it onto the window. The tracker address, hash and size are read from the file.
- Work with several torrents at once: every torrent lives in its own tab (**File > New**, **File > Close** or the close button on the tab, **File > Rename** or a double click on the tab). Closing a tab does not rename the others.
- A log window in every tab shows what is sent to the tracker and what the tracker answers.

### Client emulation
- Built-in emulation of the most common clients: uTorrent, BitComet, Azureus, ABC, BitLord, BTuga, BitTornado, Burst, BitTyrant, BitSpirit (choose the client and its version).
- Custom client settings: client key, peer ID, port and number of peers; new values can be generated automatically on every start.
- Options: use a TCP listener, request scrape, ignore a "failure reason" answer from the tracker.
- Proxy support: HTTP, SOCKS4, SOCKS4a and SOCKS5 with optional user name and password.

### Speed and statistics
- Fake upload and download speed (kB/s), update interval and the percentage already finished.
- Optional random values: the speed changes within the minimum and maximum you set, either with every update or only on the next update.
- Live counters: time to the next update, uploaded and downloaded amount, ratio, seeds, peers and running time.
- **Manual Update** sends an update to the tracker at once.

### Automatic stop
The torrent can be stopped automatically: after a given time, when the number of seeders or leechers falls below a value, when the uploaded or downloaded amount exceeds a value, or when the leechers/seeders ratio falls below a value.

### Sessions
- **Sessions > Save current session** (or **Stop and Save current session**) writes all tabs with their settings to a file.
- **Sessions > Load session** (or **Load session and Start**) restores them.
- **All RatioMasters** starts, stops or updates every tab, and sets the upload or download speed for all of them.

### Tray
- Minimize or close the window to the system tray (both can be switched off in **Settings**), with an optional balloon message.
- Only one copy of the program runs at a time; starting it again brings the running window to the front.

### Themes
- Light and dark themes, and an **Auto** mode that follows the Windows theme (**Settings > Theme**); the choice is remembered.
- A set of ready-made color themes is built in (Apricot, Cornflower, Crimson, Ember, Forest, Jazzberry Jam, Kelly Green, Lagoon, Las Palmas, Lavender, Lemon, Maya Blue, Midnight, Mint, Plum, Sky, Wine).
- Your own color themes from external files (see below).

#### Custom themes

To add a theme, create a `themes` folder next to `RatioMaster.exe` and put a `{themeName}.json` file there. Example:
```json
{
  "DisplayName": "Custom Theme",
  "DarkMode": true,
  "BackgroundColor": "#1E1E1E",
  "ForegroundColor": "#E9E9E9",
  "HyperlinkColor": "#00D980",
  "SelectedBackgroundColor": "#4CBB17",
  "SelectedForegroundColor": "#000000",
  "LineColor": "#262626",
  "StrongLineColor": "#454545",
  "WarnColor": "#FF4500"
}
```
- `DisplayName` is the name shown in the menu (the file name is used when it is missing); `DarkMode` makes the window frame dark.
- Colors are written as `#RRGGBB`. `BackgroundColor`, `ForegroundColor`, `HyperlinkColor`, `SelectedBackgroundColor`, `SelectedForegroundColor`, `LineColor` and `StrongLineColor` are required.
- `DisabledColor`, `MessageColor`, `InfoColor` and `WarnColor` are optional: when missing, the light or dark default is used, depending on `DarkMode`.
- Some colors have a special meaning in the main window: `MessageColor` is the **START** button, `WarnColor` is the **STOP** button, `HyperlinkColor` is the accent color (the **Manual Update** button and the values in the status bar).
- Restart the program so that it scans the folder for new theme files.

### Updates
**Help > Check for updates** looks for a new version of the program.

## What does it look like?

[<img src="https://github.com/sergiye/RatioMaster/raw/master/preview.png" alt="Themes"/>](https://github.com/sergiye/RatioMaster/raw/master/preview.png)

## Download

Get the latest version from the [releases](https://github.com/sergiye/RatioMaster/releases) page. The program is a single `.exe` file: it needs .NET Framework 4.7.2 or newer (included in current versions of Windows 10 and 11) and no installation.

## How can I help improve it?
The RatioMaster team welcomes feedback and contributions!<br/>
You can check if it works properly on your PC. If you notice any inaccuracies, please send us a pull request. If you have any suggestions or improvements, don't hesitate to create an issue.

Also, don't forget to ★ star ★ the repository to help other people find it.


[![Stargazers repo roster for @sergiye/RatioMaster](https://reporoster.com/stars/sergiye/RatioMaster)](https://github.com/sergiye/RatioMaster/stargazers)

## Donate!
Every [cup of coffee](https://patreon.com/SergiyE) you donate will help this app become better and let me know that this project is in demand.

## License

This program is free to use for **personal, home and other non-commercial purposes only**.

Any commercial use is not allowed without prior written permission from the author. This includes use inside a company or organization, bundling it with or into commercial products or services, and selling it or charging for access to it. For commercial licensing, please contact the author through [GitHub issues](https://github.com/sergiye/RatioMaster/issues).

You may share unmodified copies of the program free of charge, as long as they are used under the same terms.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
