<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/ninito-ph/UniHexagon">
    <img src="https://i.imgur.com/2FQVnuL.png" alt="UniHexagon" width="400" height="400">
  </a>


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

This is a library of commonly used functions and tools for building and manipulating hexagonal grids in Unity.

Here are the premises:
* Reasonably performant. The library was originally created as part of strategy game with a large map, and thus, it needed reasonably high performance and scalability. 
* Highly abstract. Significant attention was put into making sure architectural bounds were respected, facilitating modification.
* Unit tested. Essential if you intend to modify the implementation to suit your needs.



<!-- GETTING STARTED -->
## Getting Started

If you're looking to test and try out the plugin before you commit, clone the repo and open the Unity project. The easiest and fastest way of testing if the project works is by running all tests in the test runner.
If you just want to download and use it, head over to the releases page and grab the latest UnityPackage.

### Prerequisites

The library uses NSubstitute and FluentAssertions for Unit Tests. These are included in the project. The library should function in any recent version of Unity, although it has only been tested in 2019 and 2020 LTS.

### Installation

1. Download the latest UnityPackage and import into your project.


<!-- CONTACT -->
## Contact

Paulo Oliveira - paulo at ninito dot me

Project Link: [https://github.com/ninito-ph/UniHexagon](https://github.com/ninito-ph/UniHexagon)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [Red Blob Games](https://www.redblobgames.com/)
