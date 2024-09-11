
let citasGlobales = []; // Variable para almacenar las citas globalmente
let citaSeleccionadaId = null; // ID de la cita seleccionada para actualizar o eliminar

document.getElementById('buscarBtn').addEventListener('click', async function() {
    const nombre = document.getElementById('buscarNombre').value;

    try {
        const response = await fetch(`https://localhost:7010/api/Citas?NombreUsuario=${encodeURIComponent(nombre)}`);

        if (response.ok) {
            const citas = await response.json();
            
            citasGlobales = citas; // Guardar las citas globalmente
            console.log(citas); // Para ver el resultado en la consola
            mostrarResultados(citas);

            
        //    const nombre1 = document.getElementById('nombreUsuario');
        //    nombre1.value = 'HOLA'
            // Seleccionar automáticamente la primera cita y llenar los campos
            if (citas.length > 0) {
                seleccionarCita(citas[0]);
            }
        } else {
            // const resultadosfor = document.getElementById('formulario');
            // resultadosfor.innerHTML = '';
            console.error('Error al buscar citas:', response.status);
            alert('No se encontraron citas.');
            window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/ModeloCitas/Citas2.html';
        }
    } catch (error) {
        console.error('Error de red:', error);
        alert('Error de red al buscar citas.');
    }
});

// function mostrarResultados(citas) {
//     const resultadosDiv = document.getElementById('resultados');
//     resultadosDiv.innerHTML = '';

//     if (!Array.isArray(citas) || citas.length === 0) {
//         resultadosDiv.innerHTML = '<p>No se encontraron citas.</p>';
//     } else {
//         citas.forEach(cita => {
//             resultadosDiv.innerHTML += `
//                 <div class="card mt-2 cita-card" data-id="${cita.idCita}">
//                     <div class="card-body">
//                         <h5 class="card-title">${cita.nombreUsuario}</h5>
//                         <p class="card-text">Motivo: ${cita.motivoCita}</p>
//                         <p class="card-text">Doctor: ${document.getElementById('doctor').value = cita.idDoctor}</p>
//                         <p class="card-text">Horario: ${document.getElementById('horario').value = cita.idHorario}</p>
//                     </div>
//                 </div>
//             `;
//         });
//     }

function mostrarResultados(citas) {
    const resultadosDiv = document.getElementById('resultados');
    resultadosDiv.innerHTML = '';
    const vaciar = document.getElementById('buscarNombre');
    vaciar.innerHTML ='';

    if (!Array.isArray(citas) || citas.length === 0) {
        resultadosDiv.innerHTML = '<p>No se encontraron citas.</p>';
    } else {
        citas.forEach(cita => {
            const doctorNombre = getDoctorNombre(cita.idDoctor); // Asumiendo que tienes una función para obtener el nombre del doctor
            const horarioTexto = getHorarioTexto(cita.idHorario); // Asumiendo que tienes una función para obtener el horario en texto

            resultadosDiv.innerHTML += `
                <div class="card mt-2 cita-card" data-id="${cita.idCita}">
                    <div class="card-body">
                        <h5 class="card-title">${cita.nombreUsuario}</h5>
                        <p class="card-text">Motivo: ${cita.motivoCita}</p>
                        <p class="card-text">Doctor: ${doctorNombre}</p>
                        <p class="card-text">Horario: ${horarioTexto}</p>
                    </div>
                </div>
            `;
        });
    }

        // Agregar evento de clic a cada tarjeta de cita
    document.querySelectorAll('.cita-card').forEach(card => {
        card.addEventListener('click', function() {
            const idCita = this.getAttribute('data-id');
            const citaSeleccionada = citasGlobales.find(c => c.nombreUsuario == nombreUsuario);

            //forEach(elemet in citasGlobales)
            //{
             //   console.log("La cita: ", citasGlobales.nombreCompleto);
            //}

            if (citaSeleccionada) {
                seleccionarCita(citaSeleccionada);
            }
        });
    });
}

// Función simulada para obtener el nombre del doctor
function getDoctorNombre(idDoctor) {
    // Aquí puedes implementar la lógica para obtener el nombre del doctor
    // basado en el idDoctor o puedes usar un mapeo de id a nombre.
    const doctores = {
        1: 'Feliciano Rodriguez',
        2: 'Manuel de Jesus Galban',
        3: 'Maria Ceverino'
    };
    return doctores[idDoctor] || 'Doctor desconocido';
}

// Función simulada para obtener el texto del horario
function getHorarioTexto(idHorario) {
    // Aquí puedes implementar la lógica para obtener el texto del horario
    // basado en el idHorario o puedes usar un mapeo de id a texto.
    const horarios = {
        1: '09:00 - 10:00 AM',
        2: '10:00 - 11:00 AM',
        3: '11:00 - 12:00 AM'
    };
    return horarios[idHorario] || 'Horario desconocido';
}




function seleccionarCita(cita) {
    // Llenar los campos con los datos de la cita seleccionada
    console.log("La otra cita: " + cita);
    document.getElementById('nombreUsuario').value = cita.nombreUsuario;
    document.getElementById('motivoCita').value = cita.motivoCita;
    document.getElementById('doctor').value = cita.idDoctor;
    document.getElementById('horario').value = cita.idHorario;
    citaSeleccionadaId = cita.idCita; // Guardar el ID de la cita seleccionada
}

document.getElementById('actualizarBtn').addEventListener('click', async function() {
    
        // const data = {
        //     nombreUsuario: document.getElementById('nombreUsuario').value,
        //     motivoCita: document.getElementById('motivoCita').value,
        //     idDoctor: document.getElementById('doctor').value,
        //     idHorario: document.getElementById('horario').value
        // };
        const nombreUsuario = document.getElementById('nombreUsuario').value;
        const motivoCita = document.getElementById('motivoCita').value;
        const idDoctor = document.getElementById('doctor').value;
        const idHorario = document.getElementById('horario').value;
    
        const data ={
            nombreUsuario:nombreUsuario,
            motivoCita:motivoCita,
            idDoctor:idDoctor,
            idHorario:idHorario
        }

        try {
            const response = await fetch(`https://localhost:7010/api/Citas`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            });

            if (response.ok) {
                alert('Cita actualizada correctamente');
                // Actualizar la lista de citas
                document.getElementById('buscarBtn').click();
            } else {
                alert('Error al actualizar la cita');
            }
        } catch (error) {
            console.error('Error al actualizar la cita:', error);
        }

});

document.getElementById('eliminarBtn').addEventListener('click', async function() {

    const nombreUsuario = document.getElementById('nombreUsuario').value;
        try {
            const response = await fetch(`https://localhost:7010/api/Citas?nombre=${nombreUsuario}`, {
                method: 'DELETE'
            });

            if (response.ok) {
                alert('Cita eliminada correctamente');
                // Actualizar la lista de citas
                //document.getElementById('buscarBtn').click();
                window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/ModeloCitas/Citas2.html';

            } else {
                alert('Error al eliminar la cita');
            }
        } catch (error) {
            console.error('Error al eliminar la cita:', error);
        }

});

document.getElementById('formulario').addEventListener('submit', async function(event) {
    event.preventDefault();
    const nombreUsuario = document.getElementById('nombreUsuario').value;
    const motivoCita = document.getElementById('motivoCita').value;
    const idDoctor = document.getElementById('doctor').value;
    const idHorario = document.getElementById('horario').value;

    const data ={
        nombreUsuario:nombreUsuario,
        motivoCita:motivoCita,
        idDoctor:idDoctor,
        idHorario:idHorario
    }

    try {
        const response = await fetch('https://localhost:7010/api/Citas', {
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
            window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/ModeloCitas/Citas2.html';
 
        }


      //  window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';
    } catch (error) {
        console.error('error:', error);
    }
});

document.getElementById('cerrarSesionBtn').addEventListener('click', async function() {

    window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';

});