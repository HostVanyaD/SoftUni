function solve(input, a, b, c, d, e){
    let number = Number(input);
    let commands = [a, b, c, d, e];

    const operations = {
        'chop': (num) => num / 2,
        'dice': (num) => Math.sqrt(num),
        'spice': (num) => num + 1,
        'bake': (num) => num * 3,
        'fillet': (num) => num - num * 0.2,
    }

    commands.forEach(operation => {
        number = operations[operation](number);
        console.log(number);
    })
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');