#include "DHT11.h"
#define DHTPIN 2

DHT11 dht11(DHTPIN);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  delay(2000);
  float h,t;
  dht11.read(h, t);
  Serial.print(h);
  Serial.print("%\t");
  Serial.print("Temerature: ");
  Serial.print(t);
  Serial.println(" C");
}
