function drawARectangle(input = 5){
    let number = Number(input);

    for(let i = 0; i < number; i++){
        let line = '';

        for(let j = 0; j < number; j++){
            line += '* ';
        }
        console.log(line);
    }
}