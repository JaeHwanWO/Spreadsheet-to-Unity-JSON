# Spreadsheet-to-Unity-JSON
This project imports google's multi-sheet spreadsheet to Unity using Unity's newest package manager - UPM.

<p align="left">
    <a href="https://github.com/kimsama/Unity-QuickSheet/releases">
        <img src="https://img.shields.io/badge/release-v.1.0.0-orange.svg"
             alt="POD">
    </a>
    <a href="https://opensource.org/licenses/MIT">
        <img src="https://img.shields.io/badge/license-MIT-orange.svg"
             alt="license">
    </a>
</p>


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)

This project imports multi-sheet spreadsheet to Unity, using Unity's newest UPM- Unity Package Manager.

### Built With

We used these major frameworks in our project. 
* [GDataPlugin](https://getbootstrap.com)
* [QuickSheet](https://jquery.com)
* [Unity Package Manager](https://openupm.com/)

<!-- GETTING STARTED -->
## Getting Started
### Video Tutorial
* Getting UGSON started : Get your own OAuth Client ID
[![Getting UGSON started : Get your own OAuth Client ID](https://user-images.githubusercontent.com/39251825/121299394-4f3dde80-c930-11eb-8c18-09358422330e.png)](https://www.youtube.com/watch?v=ATm5upVuYB4)

* Getting UGSON Started: Apply to your Unity Project
[![Getting UGSON Started: Apply to your Unity Project](https://user-images.githubusercontent.com/39251825/121299506-7eece680-c930-11eb-988d-cca85e9e0465.png)](https://www.youtube.com/watch?v=IdAKoaTnWhI)

* Using UGSON in field : Real Time Reflection of UGSON
[![Using UGSON in field : Real Time Reflection of UGSON](https://user-images.githubusercontent.com/39251825/121299636-b065b200-c930-11eb-88f6-160f30d345fb.png)](https://www.youtube.com/watch?v=GQsV1hbLpYs)

### Get OAuth Client ID 
Do following steps to get your OAuth Client ID.

first go to google cloud platform’s api&services sector.
* [Google Cloud Platform](https://console.cloud.google.com/apis/dashboard)
and find the "credentials" button where lies next to the "key" icon.
<img width="1552" alt="Credentials" src="https://user-images.githubusercontent.com/80820556/121169718-40531f80-c88f-11eb-83ca-365d33d37171.png">

then click "+ create credentials", and process "Create OAuth client ID".
<img width="1552" alt="Credentials   OAuth" src="https://user-images.githubusercontent.com/80820556/121169802-595bd080-c88f-11eb-9f35-189b9ead77c3.png">

Because we just need OAuth client ID, "Application type" really doesnt matter.
for convenience, take "TVs and Limited Input devices".
<img width="1552" alt="CreateID" src="https://user-images.githubusercontent.com/80820556/121169894-76909f00-c88f-11eb-9ecb-bae66845a673.png">

click create, 
and we can get "client ID"
also json file which contains 'client_ID' and 'client_secret'.
<img width="1552" alt="CreatedID" src="https://user-images.githubusercontent.com/80820556/121170001-9b851200-c88f-11eb-93ab-57c9e0f67da8.png">

1. Install via UPM - most recommended
2. Download our project in zip and tap 'Add package from disk'

### Installation

1. We need Unity at minimum version of 2019.3.5.f1.

2. Implementation

On the tool bar, Click “Window" tab and you can see "Package Manager" under “Asset Store”.
<img width="1440" alt="PackageManager" src="https://user-images.githubusercontent.com/80820556/121171656-b8bae000-c891-11eb-9ab9-e5194dd8a1eb.png">

Click” the “+” button, and get the package.
<img width="800" alt="addPackage" src="https://user-images.githubusercontent.com/80820556/121171763-e011ad00-c891-11eb-8de1-9c925b3ee4a5.png">

There’s couple more processes to use UGSON.
Goto “Asset” > “Create” > “ugson”> “settings” > 
and click ”Select Google Data Setting" to start authentication.
<img width="933" alt="Authentication" src="https://user-images.githubusercontent.com/80820556/121171816-f4ee4080-c891-11eb-93f2-433cd83c09c9.png">

You can register your own json file by clicking "..." button.
click "Start Authentication”, and follow instructions as new window appears.
<img width="535" alt="GDataSetting" src="https://user-images.githubusercontent.com/80820556/121171926-18b18680-c892-11eb-81e2-b3ec64cf0d2e.png">

By the end of process, you can get codes that has to be pasted in “Access Code”.
Put the codes in there, and finish authentication.

As authenticaiton finishes, you can now get data from your own google spread sheet.
Goto “asset” > “create” > “ugson” > “tools “> “google “.
<img width="830" alt="Tools" src="https://user-images.githubusercontent.com/80820556/121172031-367eeb80-c892-11eb-9138-0e74b02a0b38.png">

Enter your “spreadsheet name” and, “work sheet name”.
<img width="535" alt="import" src="https://user-images.githubusercontent.com/80820556/121172111-50203300-c892-11eb-9e22-6284e302b5fe.png">

Specify your data’s type and generate. 
<img width="535" alt="enterInfo" src="https://user-images.githubusercontent.com/80820556/121172186-629a6c80-c892-11eb-915f-c0d517bb9763.png">

And voila! 
You get the asset of spread sheet in your own path.


<!-- USAGE EXAMPLES -->
## Demo
Now let’s see our awesome assets gettin updated!
<img width="1440" alt="applying_1" src="https://user-images.githubusercontent.com/80820556/121325054-40652500-c94c-11eb-8ff7-a3ab9c33f76a.png">

We have an awesome game demo that can import our UGSON library. Follow [video](https://www.youtube.com/watch?v=ATm5upVuYB4) to do so.

First get your spreadsheet. If you don’t have one, follow our first tutorial.
<img width="1243" alt="applying_2" src="https://user-images.githubusercontent.com/80820556/121325302-73a7b400-c94c-11eb-87d6-beaf54d69bd9.png">

First We’ll fix Google spreadsheet data. I'll show that Unity fetches asset datas.
You can see bullets instances here.
<img width="1243" alt="u can c bullets here" src="https://user-images.githubusercontent.com/80820556/121325330-7904fe80-c94c-11eb-921d-0b2403773767.png">

change the number 0 tower's "BulletType" from "Normal" to "Poison".
<img width="1243" alt="changed yet" src="https://user-images.githubusercontent.com/80820556/121325597-b2d60500-c94c-11eb-9026-7d0bb2c8e714.png">

<img width="1243" alt="changed" src="https://user-images.githubusercontent.com/80820556/121325608-b4073200-c94c-11eb-8892-4442b8656f22.png">

And you can see the fetched asset as you click "Download".
<img width="228" alt="changed applied" src="https://user-images.githubusercontent.com/80820556/121325624-b6698c00-c94c-11eb-97c2-483499ef3406.png">



<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/JaeHwanWO/Spreadsheet-to-Unity-JSON/issues) for a list of proposed features (and known issues).



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License
Distributed under the MIT License. See `LICENSE` for more information.

<!-- CODING CONVENTION -->
## Coding Convention
We use visual studio and '[Format document on Save](https://marketplace.visualstudio.com/items?itemName=mynkow.FormatdocumentonSave)' extension. 
Join our [discord](https://discord.gg/qjepstaa) channel 'coding-convention' to suggest better coding convention for us.

<!-- CONTACT -->
## Contact
Join our [discord](https://discord.gg/qjepstaa). We have every step of our development talked in our discord channel. Let us talk about future development path!


<!-- ACKNOWLEDGEMENTS -->
## References
* [Unity Serialization](http://forum.unity3d.com/threads/155352-Serialization-Best-Practices-Megapost) on Unity's forum for details of serialization mechanism.
* [GDataDB](https://github.com/mausch/GDataDB) is used to retrieve data from Google Spreadsheet. 
* All "*.dll" files of Google Data SDK are available at Google Data API SDK

