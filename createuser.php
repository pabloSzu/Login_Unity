<?php
include "dbconnection.php";




$userName = $_POST['userName'];
$email = $_POST['email'];
$pass = hash("sha256" , $_POST['pass'] );
//$repass = $_POST['repass'];


$sql = "SELECT userName From game.usuarios WHERE userName = '$userName'";
$result = $pdo->query($sql);

if($result->rowCount() > 0){

		  $data = array('done' => false , 'message' => "Error nombre de usuario ya existe");
		  Header('Content-Type: application/json');
		  echo json_encode($data);
		  exit();

}
else
{
  $sql = "SELECT email From game.usuarios WHERE email = '$email'";
  $result = $pdo->query($sql);

  if($result->rowCount() > 0)
  {

    $data = array('done' => false , 'message' => "Error email ya existe");
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();

  }

  else
  {

    $sql = "INSERT  into game.usuarios (userName, email, pass) values ('$userName', '$email', '$pass')";
    $pdo->query($sql);



  $data = array('done' => true , 'message' => "Usuario nuevo creado");
  Header('Content-Type: application/json');
  echo json_encode($data);

  exit();

}

  

}
 ?>
