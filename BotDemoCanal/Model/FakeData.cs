using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotDemoCanal.Model
{
    public class FakeData
    {
        private static Dictionary<string, BaseModel> _personajes;
        private static Dictionary<string, BaseModel> _ubicaciones;

        public static Dictionary<string, BaseModel> Personajes
        {
            get
            {
                if (_personajes == null || _personajes.Count == 0)
                {
                    _personajes = new Dictionary<string, BaseModel>()
                    {
                        {"jules", new Personajes("Jules Winfield", "~/Images/Jules.jpg", "Initially he is a Hitman working alongside Vincent Vega but after revelation, or as he refers to it 'a moment of clarity' he decides to leave to 'Walk the Earth.' During the film he is stated to be from Inglewood, California", "Asesino a sueldo")},
                        {"marcellus", new Personajes("Marsellus Wallace", "~/Images/Marsellus.png", "Marsellus Wallace is a gang boss and husband to Mia Wallace. He is the boss of Vincent Vega, Jules Winnfield, Butch Coolidge, and many other unknown gangsters. He is said to have thrown a man off a building for giving Mia a foot massage, and he is a victim of rape, courtesy of Zed.", "Capo")},
                        {"vincent", new Personajes("Vincent Vega", "~/Images/Vincent.jpg", @"Vincent Vega was a hitman and associate of Marsellus Wallace.

He had a brother named Vic Vega who was shot and killed by an undercover cop while on a job. He worked in Amsterdam for over three years and recently returned to Los Angeles, where he has been partnered with Jules Winnfield.", "Asesino a sueldo")},
                        {"mia", new Personajes("Mia Wallace", "~/Images/Mia.jpg", "Mia Wallace is the new wife of Marsellus Wallace. She is a rather mysterious charater, and very little is revealed about about her. She likes to wear elegant, expensive clothing, smokes the fictious brand of 'Red Apple' cigaretes, enjoys music, and is addicted to cocaine.  She is a world traveller, and goes to Amsterdam annually. She likes her burgers rare, and her $5 shakes vanilla flavored. She enjoys novelty, using playful epithets and nicknames, but she hates mindless chit chat.", "Esposa de Marcellus")}




                    };

                }
                return _personajes;
            }
        }

        public static Dictionary<string, BaseModel> Ubicaciones
        {
            get
            {
                if (_ubicaciones == null || _ubicaciones.Count == 0)
                {
                    _ubicaciones = new Dictionary<string, BaseModel>()
                    {
                        {"jjs", new Ubicaciones("Jack Rabit Slims", "~/Images/Jack.png", "First time in LA, I was hoping the restaurant in the movie with the amazing $5 milk shake is somewhere near Los Angeles. No idea what its called, is it even real?")},
                        {"cbutch", new Ubicaciones("Casa de butch", "~/Images/Butch.png", "Butch goes back to his apartment to find his father\'s watch but in the process also meets Vincent Vega in the toilet reading comics. If their first encounter at Marsellus\' club didn\'t go so well this one actually ends up worse. Butch escapes into an alleyway near Kendal Alley.")},
                        {"cjimmie", new Ubicaciones("Lugar en el valle", "~/Images/Jimmie.png", @"After taking care of Brett and his friends, Jules and Vincent head to Marsellus' club to give him back his mysterious briefcase. On the way a little mishap happens with Vincent shooting 'their guy' Marvin by mistake. With the car covered with blood they look for a place to take it off the road quickly. They end up in Toluca Lake, a neighborhood of the San Fernando Valley, at the house of Jules' friend, Jimmie, played by Mister Quentin Tarantino himself. There they soon receive the much needed help from the Wolf (Harvey Keitel).
It's unclear though if the scenes at Jimmy's house were actually filmed in Toluca Lake.")},
                    };
                }
                return _ubicaciones;

            }
        }
    }
}