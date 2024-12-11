function solve(input) {
  const n = Number(input[0]);
  let heroes = [];

  for (let i = 1; i < 1 + n; i++) {
    let [name, hP, bullets] = input[i].split(' ');

    hP = Number(hP);

    if (hP > 100) {
      hP = 100;
    }

    const hero = {
      name,
      hP,
      bullets: Number(bullets)
    }

    heroes.push(hero);
  }

  input.splice(0, n + 1);

  for (let line of input) {
    if (line === 'Ride Off Into Sunset') {
      break;
    }

    const [command, character] = line.split(' - ');
    const hero = heroes.find(x => x.name === character);

    if (!hero) {
      continue;
    }

    if (command === 'FireShot') {
      const target = line.split(' - ')[2];

      if (hero.bullets > 0) {
        console.log(`${character} has successfully hit ${target} and now has ${--hero.bullets} bullets!`);
      } else {
        console.log(`${character} doesn't have enough bullets to shoot at ${target}!`);
      }
    } else if (command === 'TakeHit') {
      let [, , damage, attacker] = line.split(' - ');
      damage = Number(damage);

      if (hero.hP > damage) {
        hero.hP -= damage;
        console.log(`${hero.name} took a hit for ${damage} HP from ${attacker} and now has ${hero.hP} HP!`);
      } else {
        console.log(`${hero.name} was gunned down by ${attacker}!`);
        heroes = heroes.filter(x => x.name !== hero.name);
      }
    } else if (command === 'Reload') {
      const bulletsNeeded = 6 - hero.bullets;

      if (bulletsNeeded == 0) {
        console.log(`${hero.name}'s pistol is fully loaded!`);
      } else {
        hero.bullets = 6;

        console.log(`${hero.name} reloaded ${bulletsNeeded} bullets!`);
      }
    } else if (command === 'PatchUp') {
      const amount = Number(line.split(' - ')[2]);
      if (hero.hP === 100) {
        console.log(`${hero.name} is in full health!`);
      } else if (hero.hP + amount > 100) {
        console.log(`${hero.name} patched up and recovered ${100 - hero.hP} HP!`);
        hero.hP = 100;
      } else {
        console.log(`${hero.name} patched up and recovered ${amount} HP!`);
        hero.hP += amount;
      }
    }
  }

  for (hero of heroes) {
    console.log(hero.name);
    console.log(` HP: ${hero.hP}`);
    console.log(` Bullets: ${hero.bullets}`);
  }
}
