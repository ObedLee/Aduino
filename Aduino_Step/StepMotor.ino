
#include <Stepper.h>

const int stepsPerRevolution = 2048;

Stepper stepp(stepsPerRevolution, 8, 9, 10, 11);

void setup() {
  // put your setup code here, to run once:
  stepp.setSpeed(10);
  
  Serial.begin(9600);
}

float angle
byte recv[2];
void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available() > 0){
    Serial.readBytes(recv,3);
    
    angle = (recv[1]*5.568888888*256+recv[2]*5.568888888);
    
    stepp.setSpeed(recv[0]);
    stepp.step(angle);
    
    Serial.write(recv, 3);
  }
}
