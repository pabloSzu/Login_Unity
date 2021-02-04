<?php
include "dbconnection.php";


$userName = $_POST['userName'];

$pass = hash("sha256" , $_POST['pass'] );

$sql = "SELECT userName From usuarios WHERE userName =  '$userName' AND pass = '$pass'";
$result = $pdo->query($sql);


if($result->rowCount() > 0){

  $data = array('done' => false , 'message' => "Bienvenido $userName");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}else{

  $data = array('done' => true , 'message' => "Error nombre de usuario");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();


}


 ?>
