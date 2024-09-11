document.getElementById('buscarBtn').addEventListener('click', async function() {

        try {
            const response = await fetch(`https://localhost:7010/api/Especialidad`, {
                method: 'GET'
            });

            
                if (response.ok) {
                    const result = await response.json();
                    alert('Datos traídos');
            
                    const resultadosDiv = document.getElementById('resultados');
                    resultadosDiv.innerHTML = '';
            
                    if (Array.isArray(result)) {
                        let tableContent = `
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th>ID Especialidad</th>
                                        <th>Nombre Especialidad</th>
                                    </tr>
                                </thead>
                                <tbody>
                        `;
            
                        result.forEach(item => {
                            // Asegúrate de que cada objeto tiene las propiedades esperadas
                            if (item.idEspecialidad !== undefined && item.nombreEspecialidad !== undefined) {
                                tableContent += `
                                    <tr data-id="${item.idEspecialidad}">
                                        <td>${item.idEspecialidad}</td>
                                        <td>${item.nombreEspecialidad}</td>
                                    </tr>
                                `;
                            }
                        });
            
                        tableContent += `
                                </tbody>
                            </table>
                        `;
            
                        resultadosDiv.innerHTML = tableContent;
                    } else {
                        alert('Los datos recibidos no son una lista.');
                    }
                } else if(response.status === 404){
                    alert( 'response.status');
                } else {
                    alert('Error al traer los datos');
                }
            } catch (error) {
                console.error('Error al procesar los datos:', error);
            }

});

document.getElementById('cerrarSesionBtn').addEventListener('click', async function() {

    window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';

});

document.getElementById('agregarBtn').addEventListener('click', async function() {
    
    const idEspecialidad = document.getElementById('idEspecialidad').value;
    const nombreEspecialidad = document.getElementById('nombreEspecialidad').value;

    const data ={
        idEspecialidad:idEspecialidad,
        nombreEspecialidad:nombreEspecialidad,
    }

    try {
        const response = await fetch('https://localhost:7010/api/Especialidad', {
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
            window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Admin/CrudEspecialidad.html';
        }


      //  window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';
    } catch (error) {
        console.error('error:', error);
    }
});

document.getElementById('actualizarBtn').addEventListener('click', async function() {
    
    const idEspecialidad = document.getElementById('idEspecialidad').value;
    const nombreEspecialidad = document.getElementById('nombreEspecialidad').value;

    const data ={
        idEspecialidad:idEspecialidad,
        nombreEspecialidad:nombreEspecialidad,
    }

    try {
        const response = await fetch(`https://localhost:7010/api/Especialidad`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Cita actualizada correctamente');
            window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Admin/CrudEspecialidad.html';

            
          //  document.getElementById('buscarBtn').click();
        } else {
            alert('Error al actualizar la cita');
        }
    } catch (error) {
        console.error('Error al actualizar la cita:', error);
    }

});

document.getElementById('eliminarBtn').addEventListener('click', async function() {

    const idEspecialidad = document.getElementById('idEspecialidad').value;
    const nombreEspecialidad = document.getElementById('nombreEspecialidad').value;

    const data ={
        idEspecialidad:idEspecialidad,
        nombreEspecialidad:nombreEspecialidad,
    }
        try {
            const response = await fetch(`https://localhost:7010/api/Especialidad`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                alert('Cita eliminada correctamente');
                // Actualizar la lista de citas
                //document.getElementById('buscarBtn').click();
                window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Admin/CrudEspecialidad.html';

            } else {
                alert('Error al eliminar la cita');
            }
        } catch (error) {
            console.error('Error al eliminar la cita:', error);
        }

});

document.getElementById('Dashboard').addEventListener('click', async function() {
    window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Admin/DashboardCitas.html';
})