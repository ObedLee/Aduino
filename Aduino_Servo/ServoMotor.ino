#include <Servo.h>

Servo servo;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  servo.attach(9);
  servo.write(0);
}

byte recv[2];
void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available() > 0)
  {

    Serial.readBytes(recv,2);

    for (int a = 0; a < recv[1]; a++)
    {
          servo.write(a);
          delay(100/(recv[0]+0.00000001));
    }

    recv[1] = servo.read();
    
    Serial.write(recv, 2);
  }
}
