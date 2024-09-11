document.getElementById('formulario').addEventListener('submit', async function(event) {
    event.preventDefault();

    const nombreCompleto = document.getElementById('nombreCompleto').value;
    const fechaNacimiento = document.getElementById('fechaNacimiento').value;
    const dirrecion = document.getElementById('dirrecion').value;
    const telefono = document.getElementById('telefono').value;
    const correo = document.getElementById('correo').value;
    const contrasena = document.getElementById('contrasena').value;
    const idRol = 1 //document.getElementById('idRol').value;

    const data = //{nombreCompleto,fechaNacimiento,dirrecion,telefono,correo,contrasena,idRol,RolID};
    {
        nombreCompleto:nombreCompleto,
        fechaNacimiento:fechaNacimiento,
        dirrecion:dirrecion,
        telefono:telefono,
        correo:correo,
        contrasena:contrasena,
        idRol:idRol,
    }
    console.log(data);
    
    try {
        const response = await fetch('https://localhost:7010/api/Registro', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

      
        if (response.ok) {
            const result = await response.json();
            alert('Registro Guardado con Exito');
            console.log(result);
            window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';
        }
    } catch (error) {
        console.error('error:', error);
    }
});

