Reto: explica que fue lo que sucedió o que cambio detectas con respecto a la versión anterior de tu 
aplicación elaborada anteriormente.

Para empezar Inyección Incorrecta de Scoped en Singleton: Cuando la aplicación intenta crear una instancia de MangaService como Singleton, también necesita instanciar todas sus dependencias. 
Si esas dependencias están registradas como Scoped, no pueden existir durante toda la vida de la aplicación, lo que genera un error.

Duplicación y Conflicto en la Inyección de Dependencias: Has registrado MangaService varias veces con diferentes ciclos de vida (Scoped, Transient, Singleton), 
lo que genera conflictos. En versiones anteriores, esto no ocurría porque los servicios se registraban una sola vez con un ciclo de vida definido.

se ha agrego una librería al proyecto que contiene registros de mangas, para poder verificar si la api aun esta en funcionamiento

