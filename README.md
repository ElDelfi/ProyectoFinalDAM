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
### 17/4/2024
Ajustado el rango del melee para que sea menos falso, y cuando se golpea solo con el puño a un enemigo este queda noqueado durante 2 segundos y se vuelve a levantar, se distingue tambien entre matarlo a melee o con una bala y genera un charco de sangre donde muera.
### 18/4/2024
Ya funciona el ataque con cuchillo, diferenciandolo del ataque cuerpo a cuerpo normal ya que elimina al enemigo, tambien con sus animaciones. Hoy no tuve mucho tiempo para seguir más, lo bueno es que ya funcionan las 3 armas y el cuerpo a cuerpo bien.
### 20/4/2024
Animadas piernas de los enemigos, creado script sencillo para la IA en el que el enemigo persigue y dispara al jugador si esta en cierto rango ,y pequeños cambios en otros scripts. Al final me llevo mucho más de lo esperado ya que las piernas de los enemigos me dieron muchos problemas y al final cree otra animación distinta en  vez de reutilizar el controlador de las piernas del personaje, y tambien fallos para que disparara el enemigo, pero bueno poco a poco aunque no estaba de más ir algo más rápido, también desactivo la IA cuando muere o es noqueado(en este caso luego se activa de vuelta) un enemigo que si no se siguen moviendo.

Lo añadí ahora que se me había olvidado, que cuando un arma lanzada golpea a un enemigo es noqueado.
### 21/4/2024
No querías seguir con los enemigos que estaba algo pillado asi que hice las ventanas que se rompen al lanzar un arma o dispararles, y las puertas que al final me quedé atrancado estoy investigando aun sobre los HingePoint2d ya que no estoy satisfecho con el resultado, ya que se mueven muy raro y en cualquiera de los extremos, tengo que mejorarlas, al chocar la puerta con un enemigo este queda noqueado.
### 22/4/2024
Creados prefabs, +500 y +1000 prefabs que se crean cuando se elimina/noquea a un enemigo, tengo problemas cuando es noqueado ya que se llama varias veces hay que arreglar eso, creado objeto vacío ScoreController con el script para manejar los combos y multiplicadores, aun estoy haciendo pruebas con el tiempo y mantenerlo se ve en el script score, tambien estuve pensando en las ejecuciones para cuando un enemigo esta noqueado y ahora en vez de desactivar las colisiones las pongo como trigger para así poder activar más adelante para la ejecución aún tengo que pensarlo simplemente se me paso por la cabeza ese comienzo.
Ahora cuando una bala alcanza al personaje se desactiva todo lo importante como movimiento, rotación..., y se pone un sprite de muerte  ,al pulsar R se resetea todo y la escena vuelve a empezar, así ya empiezo a manejar el SceneManager que me va a hacer falta.
### 23/4/2024
Estuve investigando sobre la creación de GUI e hice un texto simple de pulsar R para reaparecer cuando mueres que luego desaparece, y arriba a la derecha un texto con el combo y puntuación actual, arreglado bug que al matar enemigos contaban varias veces, lo arregle cambiando el tag a uno nuevo "Dead" cuando mueren la primera vez así no se duplican puntuaciones y ahora cuando un enemigo esta noqueado se le puede disparar y cuenta como 1000 puntos, ya que es muy complejo hacer una ejecución como en el juego original, me gustaría hacer algo parecido pero solo si tengo tiempo ya que tiene pinta de ser un pozo de horas, pero más adelante o incluso por mi cuenta aunque acabe el plazo del proyecto. No hubo mucho avance hoy pero bueno algo es algo (perdí una burrada de tiempo porque soy imbécil y estaba intentando usar el objeto del texto como TextMeshPro en  vez de TextMeshProUGUI).

Y al final todo esto fue para no ponerme con la IA de los enemigos que es un cristo y eso si que me va a llevar mucho tiempo que es bastante complicado. Pero tengo que hacerlo.
### 24/4/2024
Estuve viendo tutoriales sobre  creación de menús y ahora al iniciar el juego tienes opciones para salir, ajustes y jugar, todas funcionando, y mientras juegas si pulsas ESC se abre un menú de pausa y podemos continuar, salir al menú o reiniciar el nivel actual. La estética es horrible ya que no toqué nada pero quería que funcionara primero ya se pondrá bonito. Tuve un par de errores al unir eventos a botones de la UI, pero nada del otro mundo, menos mal que los menús son menos coñazo que en LibGDX.
(todo esto para no ponerme con los enemigos)
### 25/4/2024
Hoy escogí una fuente para el juego, hice un script para animar las letras en un efecto de onda, otro para hacer que tenga un efecto de movimineto infinito la imagen de fondo y puse todo con colores y mejoré la estética considerablemente, no me acaba de convencer del todo la imagen de fondo pero bueno ahora solo es cambiarla y ya, lo gordo ya está hecho, pero entre elegir y probar cosas eché ya varias horas, estas cosas siempre me llevan mucho tiempo. Dejé un slider en los ajustes que utilizaré para ajustar el sonido cuando se lo incluya al juego. Tuve unos problemas al pausar ya que no se movían los efectos al parar el Time del juego pero busqué y descubrí unscaled time que no se ve afectado y ya lo solucioné.
### 26/4/2024
Hoy quería tomarme el día algo más de relax, y he creado un Sound Manager en la pantalla del menú que se usa para todos los sonidos del juego, descargue varios (todos de freeassets.org), y los hice funcionar, disparos de armas, mertes, cristal etc..., tuve un par de problemillas pero nada, esto fue bastante sencillo y le da un toque al juego, y para probar música en el menú y jugando con loop puse una canción Racer X de Big Black que la quitaré que si que tiene copyright simplemente la dejé para hacer pruebas porque me gusta. Tal vez más a la noche hago algo con un slider en ajustes para el volumen pero solo si tengo tiempo. Por hoy me doy por satisfecho que quiero descansar.
Y arreglado un bug que despues de una ejecución se volvía a levantar por el script de la IA que no lo desactivaba en ese caso.
### 27/4/2024
Hoy he terminado los ajustes de sonido del juego, no sé si le pondré alguna  opción más en el futuro, por ahora lo voy a dejar así para ponerme con otras cosas, tengo que pensarlo. Tuve que cambiar unas cuantas cosas de la clase de Sound e investigar sobre los AudioMixer y audiomixergroups para diferenciar entre canales de audio, ya que he separado los canales de SFX y música para poder ajustarlos al gusto del jugador, uso las preferences para guardar los datos de los slider y volver a cargarlos si existen, al final me llevo bastante más de lo que esperaba ya que me dio problemas al no saber usar el mixer ya que al principio no sonaba por ahí el audio y diferenciar los canales, además luego al cargar las preferences lo puse en el load de los settings pero claro no se carga si no pulsas en ajustes y lo tuve que mover al MainMenu Load.
Mañana me pondré con la IA ya que los enemigos más estúpidos no pueden ser.
### 29/4/2024
Estoy intentando mejorar la IA de los enemigos, cree un enum para los estados, ahora al empezar esta roaming cogiendo puntos aleatorios, si el personaje entra en rango lo persigue y si se acerca más le empieza a disparar, no me convence aún, tengo que tener en cuenta si se choca con paredes y que no vea atravesando paredes al jugador, pero no sé como hacer eso aún, tengo pensado que vuelva a su posición inicial si se aleja mucho el jugador pero eso está comentado que no funcionaba bien. Por hoy lo deho que ya son las 12:30 y tengo que madrugar.
Ya tienes subido en issues un vídeo pequeñito de lo anterior a esto (esta parte fue despúes de grabar el vídeo)
### 30/4/2024
Estuve intentando mejorar el movimiento de los enemigos para que no me vean atravesando paredes pero tengo que investigarlo mejor ya que no fui capaz tal vez veo como usar un NavMesh o RayCast, tengo que ponerme con ello, pero lo deje aparcado por hoy e hice un controlador para los niveles que detecta cuando se elimina a todos los enemigos, por ahora solo sale un mensaje pero funciona, arregle unos fallos de las animaciones al soltar arma que era una chorrada, cree prefabs de las armas, puertas y ventanas. Y ahora al recoger un arma con munición abajo a la izquierda aparece un textmesh con las balas restantes en el arma, los enemigos ahora al morir sueltan el arma que tenían equipada y con las balas que le queda, es decir si un enemigo te dispara 3 veces y el arma tiene 30 balas lo detecto y va a tener 27 restantes, y obviamente si nos quedamos sin balas no podremos disparar y nos veremos obligados a lanzar el arma, esto al final fue algo lioso de hacer y con algún fallo que fui solucionando (comentados en el código) pero parece que funciona bien.

Y no, no probé a grabar con OBS este domingo pruebo y te subo otro vídeo con audio. También me gustaría hacer que si un enemigo está desarmado y tiene cerca un arma que la recoja, pero primero que no me vean por las paredes y animarlos. Y creo que no lo mencioné pero si noqueamos a un enemigo este perderá el arma equipada pero volverá a levantarse.
### 1/5/2024
Hoy descubrí bastantes problemas con el tema de la munición ya que cambiaba el prefab y despues al reaparecer las balas no se reseteaban, al intentar arreglarlo seguía dando problemas y al final lo solucioné separando en dos variables, munición actual e inicial, se puede ver en el código, todo eso ya fue un buen rato, ahora el enemigo está animado y distingue entre el arma que tiene equipada o si no tiene (aún hay que pulirlo pero al menos funciona), también cambia la cadencia y todo lo del arma dependiendo de cual tenga equipada, y creada una furgoneta que aparece con las puertas cerradas y una vez eliminemos a todos los enemigos de la escena aparecerá un mensaje en pantalla "Return to the Van" y al acercarnos a la parte trasera, mediante un trigger vuelvo al menú principal (no estaría de más una transición tengo que ver).
### 2/5/2024
Arreglado bug de ventanas, cada nivel ahora guarda la mejor puntuación y al cargarlo si tenemos algún record aparece un texto arriba a la izquierda con la mejor puntuación, intente arreglar las puertas pero no doy sacado una solución, y por curiosidad hice un script que cambia el color de fondo de la cámara cuando no hay sprites y quedaba curioso aún tengo que retocarlo pero no está mal, y organicé todo para hacer un nivel estructurado, mañana seguiré con los enemigos.