
document.getElementById('buscarBtn').addEventListener('click', async function() {

        try {
            const response = await fetch(`https://localhost:7010/api/Dashboard`, {
                method: 'GET'
            });

            if (response.ok) {
                const result = await response.json();
                alert('Datos traídos');
                renderTable(result);
            } else {
                alert('Error al traer los datos');
            }
        } catch (error) {
            console.error('Error al procesar los datos:', error);
        }
    });

 
    document.getElementById('buscarNombreUsuarioBtn').addEventListener('click', async function() {
        const buscar = document.getElementById('BUSCAR').value;
        try {
            const response = await fetch(`https://localhost:7010/api/Dashboard/PorUsuario?nombre=${buscar}`, {
                method: 'GET'
            });

            if (response.ok) {
                const result = await response.json();
                alert('Datos traídos');
                renderTable(result);
            } else {
                alert('Error al traer los datos');
            }
        } catch (error) {
            console.error('Error al procesar los datos:', error);
        }
    });

    // Buscar por Nombre de Doctor
    document.getElementById('buscarNombreDoctorBtn').addEventListener('click', async function() {
        const buscar = document.getElementById('BUSCAR').value;
        try {
            const response = await fetch(`https://localhost:7010/api/Dashboard/PorDoctor?nombre=${buscar}`, {
                method: 'GET'
            });

            if (response.ok) {
                const result = await response.json();
                alert('Datos traídos');
                renderTable(result);
            } else {
                alert('Error al traer los datos');
            }
        } catch (error) {
            console.error('Error al procesar los datos:', error);
        }
    });

    // Buscar por Horario
    document.getElementById('buscarHorarioBtn').addEventListener('click', async function() {
        const buscar = document.getElementById('BUSCAR').value;
        try {
            const response = await fetch(`https://localhost:7010/api/Dashboard/PorHorario?nombre=${buscar}`, {
                method: 'GET'
            });

            if (response.ok) {
                const result = await response.json();
                alert('Datos traídos');
                renderTable(result);
            } else {
                alert('Error al traer los datos');
            }
        } catch (error) {
            console.error('Error al procesar los datos:', error);
        }
    });

    // Cerrar sesión
    document.getElementById('cerrarSesionBtn').addEventListener('click', function() {
        window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';
    });

    // Función para renderizar la tabla de citas
    function renderTable(data) {
        const resultadosDiv = document.getElementById('resultados');
        let tableContent = `
            <table class="table">
                <thead>
                    <tr>
                        <th>Nombre Usuario</th>
                        <th>Motivo Cita</th>
                        <th>Nombre Doctor</th>
                        <th>Horario</th>
                    </tr>
                </thead>
                <tbody>
        `;

        data.forEach(item => {
            tableContent += `
                <tr>
                    <td>${item.nombreUsuario}</td>
                    <td>${item.motivoCita}</td>
                    <td>${item.nombreDoctor}</td>
                    <td>${item.horario}</td>
                </tr>
            `;
        });

        tableContent += `
                </tbody>
            </table>
        `;

        resultadosDiv.innerHTML = tableContent;
    }

    document.getElementById('cerrarSesionBtn').addEventListener('click', async function() {

        window.location.href = 'C:/Users/david/OneDrive/Escritorio/MATERIAS_DE_ ITLA/Quinto_Cuatrimestre/Programacion_2/PROGRAMAS/ProyectoFinalP2/Fronend/Login/Login.html';
    
    });