const { open } = require('node-adodb');
const download = require('image-downloader');
const fetch = require('node-fetch');
const connection = open(`Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\\Users\\amitn\\source\\repos\\Navebsite\\Navebsite\\App_Data\\Navebase.accdb';`);



const url = 'http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=7CB796999B3B99E7252BCA46AC1C9CBC&steamid=76561198217085696&format=json&include_appinfo=true';

function getRandomDate(from, to) {
    from = from.getTime();
    to = to.getTime();
    return new Date(from + Math.random() * (to - from));
}

(async () => {

    const query = await connection.query("SELECT * FROM Games")
    let data = [...query];
    data.forEach(game => {

        var genres = [];
        while(genres.length < Math.ceil(Math.random() * 3)) {
            var r = Math.floor(Math.random() * 5) + 1;
            if(genres.indexOf(r) === -1) genres.push(r);
        }

        genres.forEach(genre => {
            const sql = `INSERT INTO GameGenres
            (Game, Genre)
            VALUES
            (${game.ID}, ${genre})`.replace(/\n/g, "");
            connection.execute(sql)
        })


    })
    

})();


async function genGames() {
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
}