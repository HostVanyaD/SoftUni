function solve(speed, area){
    let limits = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential':20,
    }

    let speedLimit = limits[area];

    if (speed <= speedLimit){
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        let diff = speed - speedLimit;
        let status = '';

        if (diff <= 20){
            status = 'speeding';
        } else if (diff <= 40){
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${diff} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');