var arma : Transform;

private var VelocidadX = 0.4;  
private var VelocidadY = 0.4;
private var VelocidadZ = 0.4;

var A : Vector3; // posicion del arma apuntando
var C : Vector3; //posicion del arma sin apuntar
private var D : Vector3;

var anim : Animation; // clocar en Animation que hay en el objeto

private var DisparandoAnim : boolean;

var NombreAnimacionRecarga : String;
var NombreAnimacionDisparar : String;
var NombreAnimacionDispararApuntando : String;

function Start () {
transform.position = C;
}
 
function Update () {

 var newX = Mathf.SmoothDamp(arma.transform.localPosition.x, D.x, VelocidadX, .1);
 var newY = Mathf.SmoothDamp(arma.transform.localPosition.y, D.y, VelocidadY, .1);
 var newZ = Mathf.SmoothDamp(arma.transform.localPosition.z, D.z, VelocidadZ, .1);
     
  transform.localPosition.x = newX;
  transform.localPosition.y = newY;
  transform.localPosition.z = newZ;

    
if (Input.GetButton("Fire2")) {        
   D.x = A.x;
   D.y = A.y;
   D.z = A.z;
} else {        
   D.x = C.x;
   D.y = C.y;
   D.z = C.z;
}
}

function Disparar () {
Debug.Log("animFire");

if(DisparandoAnim == false){ // animacion disparando
GetComponent.<Animation>().Play(NombreAnimacionDisparar); // escribir nombre de la animacion en este caso "disparar"
}
if(DisparandoAnim == true){ // animacion disparando y apuntando
GetComponent.<Animation>().Play(NombreAnimacionDispararApuntando); // escribir nombre de la animacion en este caso "disparar"
}
}

function Recargar () {
Debug.Log("animReload");
GetComponent.<Animation>().Play(NombreAnimacionRecarga); // escribir nombre de la animacion en este caso "Reload"
}

function t () {
Debug.Log("t");
DisparandoAnim = true;
}

function f () {
Debug.Log("f");
DisparandoAnim = false;
}