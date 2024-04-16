# ProyectoFinalDAM
Juego basado en Hotline Miami hecho con Unity

### 20/3/2024
Ya que empiezo de 0 con Unity para comenzar pensé en que sería buena idea realizar algunos cursos de OpenWebinars para ello hoy hice el curso entero de introducción a Unity (certificación subida)
### 21/3/2024
 Hoy configuré mi proyecto inicial y lo subí al repositorio, tuve que añadir un .gitignore para Unity, además realicé todo el curso de API de Unity (certificación subida)
### 22/3/2024
 Hoy he creado los scripts simples de movimineto en 4 direcciones, tengo que hacer las diagonales, otro para centrar la camara con el personaje, y tbn que siga el personaje al cursor, tuve un error muy tonto en el que pensaba que tenía un error ya que mi personaje se movía solo hacia abajo y era porque le puse gravedad sin querer, media hora perdida con esa chorrada ,además realicé todo el curso de matemáticas aplicada Unity (certificación subida).

(Más tarde el mismo día) Ahora ya permite moverse en diagonal y no se duplica la velocidad (antes se sumaban las dos velocidades si se usaban dos teclas para moverse), y nueva mecánica ahora el jugador puede pulsar shift y con el raton mirar alrededor para poder ver más lejos, siendo el limite el punto en el que ya no se puede ver al jugador.
### 23/3/2024
  He conseguido unos sprites y assets de un proyecto de otro clon de hotline miami para unity, tal vez mas adelante los cambio o algo pero por ahora quedaran estos así tbn puedo hacer pruebas, que yo no sirvo de diseñador.
  Despues de los atracones que me metí estos días ahora voy a descanasar hasta el día 2, ya que ahora estoy bastante más tranquilo al entender mejor Unity y su funcionamiento antes me estaba agobiando yo solo.
### 06/4/2024
Esta semana al empezar las prácticas fue mortal, y estaba tan cansado que ponerse con esto era imposible.

Ahora retome el proyecto para seguir y estaba intentando con tutoriales usar el animador de Unity, conseguí que se moviera el personaje y transicionar entre estados, poco a poco. Entre lo que queda de hoy y mañana espero hacer más progresos pero esta semana fue dura.
### 07/4/2024
Creado objeto hijo Legs para el personaje, ya que en el Hotline Miami se mueven distinto al torso y solucionado un problema con sus ángulos y las animaciones, creado prefab de Bullet y con un pequeño codigo para que al colisionar con algo se eliminen, y scripts para el personaje para disparar y coger arma, pero estos dos ultimos bastante brutos como primera aproximación ya que me estaban dando muchos problemas ahora ya mejor.

Me estaba/estoy agobiando ya que al ser principiante con Unity y así me está dando miedo la escala del proyecto porque voy a tener que tener en cuenta que tipo de arma cojo, y según eso cambiar animaciones y puntos de disparo y cosas así que en un primer momento ni te planteas que vayan a ser un problema y me está asustando.

Puse unas cuantas variables e ideas en el código sobre como afrontar eso pero no sé, tambien arreglados unos problemas con balas infinitas poniendo cooldown al firerate y el ángulo en el que aparecían entre otras cosas, con estas chorradas al final ya eche casi todo el día.
### 08/4/2024
Hoy cree unas cuantas animaciones más e hice un sistema de melee bastante rudimentario despues de pensar como hacer, editadas algunas variables más y pocos cambios a mayores, tengo en la cabeza una idea asignando nombres a cada arma para luego saber que animación usar, pero por hoy ya está que con el trabajo quiero descansar un poco de pantallas.
### 09/4/2024
Arreglado el melee infinito y poco más hoy estaba algo bloqueado y tuve poco tiempo espero que esta semana mejor.
### 11/4/2024
Conseguí pasarle un objeto arma al personaje al recogerla del suelo para asi diferenciar entre los distintos tipos, depndiendo del nombre cambiare propiedades, tengo pensado hacer que con la escopeta aparezcan más balas y que la uzi y la pistola se diferencien por la cadencia, perdí una burrada de tiempo porque soy imbécil y creía que no funcionaba el sistema de recoger las armas, pero era por un tema de hitbox, aun no estoy del todo contento necesito retocarlo más para encontrar una forma que funcione mejor. Hoy tampoco fue un gran día pero no quería irme a dormir sin tocar el proyecto aunque fuera poco. Día largo.
### 13/4/2024
Conseguí cambiar entre animaciones dependiendo del arma que se recoja y que dispare, faltan retocar y añadir más, he cambiado el FirePoint del cual salen las balas para que quede mejor y empecé con el script de lanzar las armas por ahora solo las elimina y cambia la animacion, arreglado problema creado por esta nueva función en el cual se eliminaba instantaneamente al recoger, ya que no habia cooldown.
Falta retocar todo esto pero al menos consegui avanzar, perdí mucho tiempo para que funcionaran las animaciones y con el FirePoint al principio intente moverlo segun el arma por codigo pero con la rotación salía mal, se me fueron bastantes horas por esos dos motivos, dejo comentadas las lineas de intentos.
Me parece que voy muy lento o no avanzo lo suficiente.
### 14/4/2024
Por variar empecé con el tilemap y sus colisiones para aprender a usar las nuevas herramientas, hay que solucionar problemas con las colisiones en las esquinas y el personaje a veces atraviesa los muros, intente arreglar todo esto pero aun no fui capaz tengo que investigar más, pero al final ya eché mucho tiempo hoy arreglando otras cosas porque al principio no tenía ni idea de como usar el sprite editor y los tiles eran muy grandes para cada imagen y al final investigando era por los pixels per unit, pero yo al principio lo que hice fue hacer más pequeña cada celda del grid lo cual no salió muy bien, tambien ordené todo por layers ya que no aparecían las balas ni el personaje al principio, quedó creada una pequeña sala para pruebas con paredes y suelo. 
Arreglado tambien problema al recoger armas que no funcionaba bien y fue simplemente cambiar la funcion del pulsado del ratón por otra.
### 15/4/2024
Modificado el script de player attack, como el método para seguir el ratón para pasarle el ángulo y dirección en el cual lanzar el arma, cambiado el script de bala para que desaparezcan después de x segundos aunque no colisionen con nada, y creado el script de lanzar el arma en el cual se mueve en la dirección y ángulo que apuntemos al pulsar el botón derecho del ratón durante unos segundos o hasta que choque con algo que no sea el jugador.
Tuve algunos problemas al principio, porque hay que volver a hacer que sea un sensor o no cuando se lanza y choca además de las físicas y sus valores pero todo bien ahora.
### 16/4/2024
Creados prefabs con efectos para colisiones de balas, sangre para los enemigos y otro efecto contra paredes, pequeños ajustes a distintos scripts para que funcione todo, y cambiado el script de atacar ahora cuando tienes la escopeta genera 5 balas con dispersión para hacer el efecto de escopeta, me llevo más tiempo del esperado pero bueno fue saliendo, tambien cambie el firerate de las armas y el order layer para que tengan sentido las cosas.