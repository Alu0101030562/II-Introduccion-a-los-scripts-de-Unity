# Interfaces Inteligentes - Introducción a los scripts de Unity

Esta práctica constará de 3 ejercicios sobre scripts de unity. Lo primero que tendremos que hacer es insertar los elementos en la escena, para ello insertaremos un plano que hará la funcion de suelo, una esfera y un cubo. Una vez hecho esto haremos una serie de pruebas para saber los resultados sobre fisicas entre objetos.

### Ejercicio 1.

a) Ninguno de los objeto será físico.

Aquí no ocurrirá nada puesto que al no tener fisicas ningún objeto simplemente se traspasan.

b) La esfera tiene físicas, el cubo no.

En este caso, al tener la esfera físicas pero el cubo no, la esfera podra atravesar el cubo al moverse.

c) La esfera y el cubo tienen físicas.

Igual que el caso anterior, aunque esta vez ambos elementos tienen físicas, y ambos pueden atravesarse entre si.

d) La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo.

Ambos objetos caen por la gravedad al suelo, y al tener la esfera una masa 10 veces superior al cubo, podra mover el objeto mas lejos en caso de colisión, en el caso contrario el objeto se moveria menos puesto que la masa del cubo es inferior a la de la esfera.

e) La esfera tiene físicas y el cubo es de tipo IsTrigger.

El cubo al ser de tipo IsTrigger, ignorará las fisicas por lo que atravesara la esfera y no hará contacto en ningún momento.

f) La esfera tiene físicas, el cubo es de tipo IsTrigger y tiene físicas.

En este caso como el cubo tiene físicas y es de tipo IsTrigger, caerá al vacío atravesando el suelo creado.

g) La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo, se impide la rotación del cubo sobre el plano XZ.

Ambos objetos caen por la gravedad al suelo, y al tener la esfera una masa 10 veces superior al cubo, podra mover el objeto mas lejos en caso de colisión, en el caso contrario el objeto se moveria menos puesto que la masa del cubo es inferior a la de la esfera. Al impedir la rotacion en el plano XZ tendrá un movimiento limitado.

### Ejercicio 2

En este ejercicio tendremos que conseguir que un objeto 3D (en este caso un cubo) avance en el plano en todas las direcciones posibles, además de que pueda rotar sobre su eje OY mediante el uso de un script en C#.

Usando la misma escena del ejercicio anterior seleccionamos el cubo, y le añadiremos un script llamado *TranslationRotation* donde programaremos las acciones que debe realizar el cubo.

Este seria el contenido del Script *TranslationRotation*:

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TranslationRotation : MonoBehaviour
    {
        // Start is called before the first frame update
        public float moveSpeed = 1f;
        public float rotationSpeed = 2f;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Translation
            if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift)) {
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }

            //Rotation
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.RotateAround(transform.position, Vector3.down, rotationSpeed);
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
            }
        }
    }
    

Lo primero que declaramos son dos variables, las cuales las utilizaremos para establecer la velocidad de desplazamiento y de rotación. Ambas son declaradas como públicas para que desde la interfaz de Unity podamos modificar los valores sin tener que estar modificando el script cada vez que queramos realizar una prueba.

Tras establecer los valores que creamos adecuados pasamos a la función *Update()* para que se esté ejecutando constantemente. En este área codificaremos la traslación y la rotación del objeto cuando el usuario presione las teclas habilitadas para ello. La función *Input* junto con la funcion *GetKey* permite al programa estar a la escucha para ver si el usuario presione la tecla que hemos especificado en la función *GetKey*. En nuestro caso hemos codificado las teclas A, S, W, D para manejar el desplazamiento del cubo.

Una vez el usuario presione esas teclas, se ejecutará la orden que está dentro del *If*. El cubo consigue desplazarse gracias al *transform*, ya que manipula las coordenadas de los ejes X, Y y Z. Añadiéndole la función *Translate* para que realice el dezplazamiento, debemos utilizar el objeto *Vector3* junto con su dirección (forward, back, left, right) para que solo modifique el eje correspondiente con su movimiento. Dicho objeto debe multiplicarse por la velocidad que establecimos al principio del script y por otra nueva variable, *Time.deltaTime*, la cual va a escalar el tamaño del movimiento por el frame time que nuestra CPU sea capaz de procesar para que parezca que el objeto se mueve a una velocidad regular. Una vez configurado esto, el desplazamiento del cubo ya estaría terminado.

Por otro lado, para realizar la rotación seguiremos el mismo procedimiento excepto por dos diferencias. La primera de ellas la podemos observar que a parte de pulsar la tecla de dirección antes configurada, también el usuario debe pulsar la tecla Shift para que así el programa diferencie entre la traslación y la rotación utilizando prácticamente las mismas teclas. La segunda diferencia tiene relación con la función que utiliza *transform*, en este caso hemos utilizado la función *RotateAround* cuyos parámetros son la posición actual del objeto, el objeto *Vector3* que vaya a modificar el eje correspondiente para realizar el giro sobre el eje OY, y por último la velocidad de giro que establecimos con anterioridad.

**Gif del ejercicio**

![Ejercicio 2](https://user-images.githubusercontent.com/72420000/138789291-52056d25-4f2e-4588-9f59-905549a7f94c.gif)


### Ejercicio 3

Para esta práctica usaremos la escena de los ejercicios anteriores, añadiendo límites al terreno que hacen de muro. 

#### Player

En este apartado se nos describe que el comportamiento del objeto Jugador debe poder detectar las colisiones que tenga con los cilindros que estén dentro de nuestro entorno para poder generar un contador de dichas colisiones. Además, debemos implementar el script correspondiente para que dicho objeto Jugador pueda desplazarse, mediante Físicas, con las teclas W, S, A y D en las distintas direcciones.

Script del objeto Jugador:


    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using UnityEngine;
    using UnityEngine.UI;

    public class player : MonoBehaviour
    {
        public float moveSpeed = 10f;
        private Rigidbody rb;
        private float contador;
        public Text texto;
        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            rb = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
           if (Input.GetKey(KeyCode.W))
           {
                rb.AddForce(Vector3.forward * moveSpeed);
           }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector3.back * moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * moveSpeed);
            }
            SetDistance();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Cylinder")
            {
                contador = contador + 1;
                transform.localScale += scaleChange;
            }
        }

        void SetDistance()
        {
            texto.text = "Contador: " + contador.ToString();
        }
    }
    
    
En primer lugar, para generar el movimiento del objeto Jugador mediante físicas utilizaremos la función *AddForce()*. Para ello, primero debemos proporcionarle un *Rigidbody* al objeto desde la interfaz de Unity para poder manipularlo desde el script. Tras realizar ese paso, hemos generado un objeto *Rigidbody* en el cual hemos guardado el *Rigidbody* del objeto Jugador. A continuación, hemos generado una serie de *If* para que el objeto se pueda mover en las diferentes direcciones dependiendo de las teclas que pulse el usuario. Por ejemplo, si el jugador pulsa la tecla W, se le aplicará una fuerza al *Rigidbody* con la función *AddForce()* para que en este caso avance en la dirección positiva del eje Z, mediante el uso de *Vector3.forward* y de una variable que utilizamos como regulador de velocidad del desplazamiento, *moveSpeed*.

En segundo lugar, generaremos el contador de colisiones con los cilindros. Para ello, lo primero que debemos hacer es hacer uso de la función *OnCollisionEnter(Collision collision)* para que el motor detecte cuándo el objeto Jugador entra en colisión con otro objeto. Para poder especificar que solo queremos que detecte cuando el jugador colisione con un cilindro, debemos asignar a los objetos Cilindros de nuestro entorno un "Tag" para clasificarlos y que nos sea más fácil de referenciar. Por lo tanto, cuando colisionamos con un Cilindro, el objeto Collision accede al gameObject con el que colisionó y que nos devuelva el "tag" con el que está referenciado. Así, si dicho "tag" coincide con el que hemos especificado nosotros, incrementará una unidad en el contador.

El contador que hemos generado lo podremos visualizar mientras el juego se está ejecutando, ya que hemos añadido un Canvas o también conocido como "lienzo" para que siempre se vea en pantalla independientemente de lo que se sitúe en el trasfondo. Como hijo de dicho Canvas hemos generado un Text para que muestre el contador en una esquina de la pantalla. Para poder llevar a cabo dicha tarea, debemos volver al script y generar una función auxiliar que transforme el contador a tipo String y así se pueda asignar al Text del Canvas.

Por último, en la función Start(), añadimos una línea para cambiar el color de nuestro objeto Jugador a azul, para que se diferencie del resto de nuestro entorno.

También añadiremos la función de que en caso de que el jugador toque algún cilindro, aumente de tamaño.

Para conseguir que el cubo aumente de tamaño o disminuya en función de quien se acerque lo configuraremos con la función *OnTriggerEnter(Collider col)*. Para que el cubo detecte con cierta anterioridad que un objeto esta cerca de el hemos generado el collider. Cuando un objeto entra en el collider, el cual debe tener la opcion "IsTrigger" activada, el programa lo detecta pero no choca con el, solo lo traspasa y aumenta o disminuye su tamaño en funcion del objeto que interactua con él. Para identificar que los objetos que entran en colisión son las esferas o el jugador, se declara de la misma forma de antes, mediante el "tag" o también podría ser con el "name" del propio objeto.

Por último se dice de añadir un tercer objeto que detecte colisiones y que se mueva con las teclas I, J, L y M. Haremos algo parecido con el objeto Player, con la diferencia de que en caso de tocar un cilindro, este no hara ningun efecto sobre el.

**Gif de la Practica**

![Ejercicio 2 3](https://user-images.githubusercontent.com/72420000/138848110-3ea558b2-065c-401b-8168-6bb4ff5e0293.gif)
