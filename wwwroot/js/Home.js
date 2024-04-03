
function convertir(value) {
    let valor = value.toString();
    return valor;
}

function SumNum(value, numero) {

    let valor = convertir(numero);
    let num = document.getElementById(valor);
    
    if (value == "+") {
        num.innerText = parseInt(num.innerHTML) + 1;
        console.log(num);
        return num
    } else {
        num.innerText = parseInt(num.innerHTML) - 1;
        return num
    }

}