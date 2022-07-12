<div align="center">

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

</div>


<br />
<div align="center">
  <a href="https://github.com/zDany01/WindowsITimeSync">
    <img src="Icon/png/128x128.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Windows Internet Time Sync</h3>

  <p align="center">
    An application that allows you to synchronize the system clock with the current internet time.
    <br />
    ·
    <a href="https://github.com/zDany01/WindowsITimeSync/issues">Report Bug</a>
    ·
  </p>
</div>



<!-- ABOUT THE PROJECT -->
## About The Project

![Product Name Screen Shot][product-screenshot]
<br>
This application was born to simplify or automate computer time synchronization.<br>
It works by executing the windows time resync command on computer startup or when requested by the user.

You may need this application if your system reports the wrong time every time the system is turned on.<br>
This issue can be caused by many things but mainly it comes from the **BIOS**.<br>
This occurs when you have a dead CMOS Battery or another operating system is storing time data in a different way than windows does.


So before trying this program, there is something that you can try to do to resolve the issue:
  - Check if your CMOS Battery is in good condition
  - Check if your local time zone information are correct
  - If you are in a dual-boot configuration, make sure that your other operating system isn't storing data time using the [UTC time format](https://itsfoss.com/wrong-time-dual-boot/)

<br><br>

## Installation
You can download the latest precompiled version of the program [here](https://github.com/zDany01/WindowsITimeSync/releases/download/v1/WindowsITimeSync.exe) or you can compile the application by yourself following these instruction.

1. Download Microsoft [Visual Studio Community](https://visualstudio.microsoft.com) Edition
2. Check the ***.NET Desktop Developer*** box and click install
3. Clone(or [download](https://github.com/zDany01/WindowsITimeSync/archive/refs/heads/main.zip)) this repository:
   ```sh
   git clone https://github.com/zDany01/WindowsITimeSync.git
   ```
4. Open the project directory and run the `WindowsITimeSync.sln` file, this will fire up Visual Studio and automatically open the project
5. Now you can compile or review the source code and make any modification you want within Visual Studio

<br><br>

## How to use
<div align=center>

![AppInterface](https://github.com/zDany01/zDany01/blob/main/Assets/WindowsITimeSync/AppInterface.png?raw=true)
</div>


Using this application isn't very hard, all you need to do is to click the _Sync Now_ Button to start the synchronization process or check the _Sync on startup_ box to automatically run it on system startup


<br><br>
## License

Distributed under the MIT License. See `LICENSE` for more information.

[contributors-shield]: https://img.shields.io/github/contributors/zDany01/WindowsITimeSync.svg?style=for-the-badge
[contributors-url]: https://github.com/zDany01/WindowsITimeSync/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/zDany01/WindowsITimeSync.svg?style=for-the-badge
[forks-url]: https://github.com/zDany01/WindowsITimeSync/network/members
[stars-shield]: https://img.shields.io/github/stars/zDany01/WindowsITimeSync.svg?style=for-the-badge
[stars-url]: https://github.com/zDany01/WindowsITimeSync/stargazers
[issues-shield]: https://img.shields.io/github/issues/zDany01/WindowsITimeSync.svg?style=for-the-badge
[issues-url]: https://github.com/zDany01/WindowsITimeSync/issues
[license-shield]: https://img.shields.io/github/license/zDany01/WindowsITimeSync.svg?style=for-the-badge
[license-url]: https://github.com/zDany01/WindowsITimeSync/blob/master/LICENSE.txt
[product-screenshot]: https://github.com/zDany01/zDany01/blob/main/Assets/WindowsITimeSync/TextLogo.png?raw=true