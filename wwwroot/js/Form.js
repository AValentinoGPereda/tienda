function formatISOLocal(fecha){
    let z = n => ('0' + n).slice(-2);
    return fecha.getFullYear() + '-' + z(fecha.getMonth()+1) + '-' + z(fecha.getDate());
}
window.onload = function(){
    let inp = document.querySelector('#i0');
    let fecha = new Date();
    fecha.setFullYear(fecha.getFullYear() - 18);
    inp.max = formatISOLocal(fecha);
}
function RellenarFormulario()
{
    
    var respuesta= confirm("Gracias por rellenar el formulario");
    
    if(respuesta==true)
    {
        return true;
    }
    else 
    {
        return false;
    }
}