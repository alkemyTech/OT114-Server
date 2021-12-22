using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    Id = 1,
                    Name = "Programas Educativos",
                    Content = "Mediante nuestros programas educativos, buscamos incrementar la capacidad " +
                    "intelectual, moral y afectiva de las personas de acuerdo con la cultura y las " +
                    "normas de convivencia de la sociedad a la que pertenecen.",
                    Image = "img1",
                },
                new Activity
                { 
                    Id = 2,
                    Name = "Apoyo escolar nivel primario",
                    Content = "El espacio de apoyo escolar es el corazón del área educativa. Se realizan los " +
                    "talleres de lunes a jueves de 10 a 12 horas y de 14 a 16 horas en el contraturno," +
                    "Los sábados también se realiza el taller para niños y niñas que asisten a la escuela " +
                    "doble turno.Tenemos un espacio especial para los de 1er grado 2 veces por " +
                    "semana ya que ellos necesitan atención especial! Actualmente se encuentran " +
                    "inscriptos a este programa 150 niños y niñas de 6 a 15 años.Este taller está " +
                    "pensado para ayudar a los alumnos con el material que traen de la escuela, " +
                    "también tenemos una docente que les da clases de lengua y matemática con una " +
                    "planificación propia que armamos en Manos para nivelar a los niños y que vayan " +
                    "con más herramientas a la escuela.",
                    Image = "img2",
                },
                new Activity
                {
                    Id = 3,
                    Name = "Apoyo Escolar Nivel Secundaria",
                    Content = "Del mismo modo que en primaria, este taller es el corazón del área secundaria. Se " +
                    "realizan talleres de lunes a viernes de 10 a 12 horas y de 16 a 18 horas en el " +
                    "contraturno.Actualmente se encuentran inscriptos en el taller 50 adolescentes " +
                    "entre 13 y 20 años.Aquí los jóvenes se presentan con el material que traen del " +
                    "colegio y una docente de la institución y un grupo de voluntarios los recibe para " +
                    "ayudarlos a estudiar o hacer la tarea.Este espacio también es utilizado por los " +
                    "jóvenes como un punto de encuentro y relación entre ellos y la institución.",
                    Image = "img3",
                },
                new Activity
                {
                    Id = 4,
                    Name = "Tutorias",
                    Content = "Es un programa destinado a jóvenes a partir del tercer año de secundaria, cuyo " +
                    "objetivo es garantizar su permanencia en la escuela y construir un proyecto de " +
                    "vida que da sentido al colegio.El objetivo de esta propuesta es lograr la " +
                    "integración escolar de niños y jóvenes del barrio promoviendo el soporte " +
                    "socioeducativo y emocional apropiado, " +
                    "desarrollando los recursos institucionales " +
                    "necesarios a través de la articulación de nuestras intervenciones con las escuelas " +
                    "que los alojan, con las familias de los alumnos y con las instancias municipales, " +
                    "provinciales y nacionales que correspondan.",
                    Image = "img4",
                },
                new Activity
                {
                    Id = 5,
                    Name = "Encuentro semanal con tutores",
                    Content = "Individuales y grupales",
                    Image = "img5",
                },
                new Activity
                {
                    Id = 6,
                    Name = "Actividad proyecto",
                    Content = "los participantes del programa deben pensar una " +
                    "actividad relacionada a lo que quieren hacer una vez terminada la escuela y " +
                    "su tutor los acompaña en el proceso",
                    Image = "img6"
                },
                new Activity
                {
                    Id = 7,
                    Name = "Ayudantías",
                    Content = "los que comienzan el 2do años del programa deben elegir una " +
                    "de las actividades que se realizan en la institución para acompañarla e ir " +
                    "conociendo como es el mundo laboral que les espera",
                    Image = "img7",
                },
                new Activity
                {
                    Id = 8,
                    Name = "Acompañamiento escolar y familiar",
                    Content = "Los tutores son encargados de articular con la familia y con las escuelas de " +
                    "los jóvenes para monitorear el estado de los tutoreados)",
                    Image = "img8",
                },
                new Activity
                {
                    Id = 9,
                    Name  = "Beca estímulo",
                    Content = "los jóvenes reciben una beca estímulo que es supervisada por los tutores." +
                    "Actualmente se encuentran inscriptos en el programa 30 adolescentes.",
                    Image = "img9",
                },
                new Activity
                {
                    Id = 10,
                    Name = "Taller Arte y Cuentos",
                    Content = "Taller literario y de manualidades que se realiza semanalmente.",
                    Image = "img10",
                },
                new Activity
                {
                    Id = 11,
                    Name = "Paseos recreativos y educativos",
                    Content = "Estos paseos están pensados para promover la participación y sentido de " +
                    "pertenencia de los niños, niñas y adolescentes al área educativa.",
                    Image = "img11",
                }
                );
        }
    }
}
