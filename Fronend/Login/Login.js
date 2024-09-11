document.getElementById('formulario').addEventListener('submit', async function(event) {
    event.preventDefault();

    const correo = document.getElementById('correo').value;
    const contrasena = document.getElementById('contrasena').value;

    const data = 
    {
        correo:correo,
        contrasena: contrasena,
    };

    try {
        const response = await fetch(`https://localhost:7010/api/Registro?Correo=${encodeURIComponent(correo)}&Contrasena=${encodeURIComponent(contrasena)}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            head: JSON.stringify(data)
        });
        if (response.ok) {
                alert('Inicio de Seccion Exitoso');
            const result = await response.json();
            console.log(result);
            if (result.rolId == 1) {
                window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/ModeloCitas/Citas2.html';
            }
            else if(result.rolId == 2) {
                window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Admin/CrudEspecialidad.html';
            }else if (result.rolId  == 3) {
                window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Doctores/Doctores.html';
            }
         }
    } catch (error) {
        console.error('error:', error);
    }
});

document.getElementById('Registrar').addEventListener('click', async function() {

    window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Registro/Registro.html';

})