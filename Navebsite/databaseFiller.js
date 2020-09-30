const { open } = require('node-adodb');
const download = require('image-downloader');
const fetch = require('node-fetch');
const connection = open(`Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\amitn\\source\\repos\\Navebsite\\Navebsite\\App_Data\\Navebase.accdb';`);

connection.query("SELECT * FROM Games").then(data => console.log(data));


const url = 'http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=7CB796999B3B99E7252BCA46AC1C9CBC&steamid=76561198217085696&format=json&include_appinfo=true';

function getRandomDate(from, to) {
    from = from.getTime();
    to = to.getTime();
    return new Date(from + Math.random() * (to - from));
}

(async () => {

    const data = await fetch(url).then(d => d.json());

    let games = [...data.response.games];

    games.forEach(async game => {

        const { appid } = game

        const bgUrl = `https://steamcdn-a.akamaihd.net/steam/apps/${game.appid}/header.jpg`;
        const logoUrl = `http://media.steampowered.com/steamcommunity/public/images/apps/${game.appid}/${game.img_icon_url}.jpg`;
        
        await download.image({
            url: bgUrl,
            dest: `./Images/GameBackgrounds/${game.appid}_bg.jpg`
        });
        await download.image({
            url: logoUrl,
            dest: `./Images/GameLogos/${game.appid}_logo.jpg`
        });
        
        let bg = `${game.appid}_bg.jpg`;
        let logo = `${game.appid}_logo.jpg`;

        const sql = `INSERT INTO Games 
        ([Game Name],
            [Game Link],
            [Description],
            [Review Status],
            Background,
            Logo,
            Developer,
            [Publish Date],
            Price) 
            VALUES
            (
            '${game.name}',
            'https://store.steampowered.com/app/${appid}/',
            'A steam imported game',
            1,
            '${bg}',
            '${logo}',
            ${Math.ceil(Math.random() * 6)},
            #${getRandomDate(new Date("10/11/2003"), new Date()).toLocaleString().replace(/\//g,"-").replace(",","")}#,
            ${Math.random() * 100}
            );`.replace(/\n/g, ' ');

            
            let r =  await connection.execute(sql)
            console.log("Inserted game " + game.name)
    });
    

})();