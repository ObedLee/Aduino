#include<LiquidCrystal.h>
#include<SoftwareSerial.h>
#include "DHT11.h"

// 핀 설정
LiquidCrystal lcd(12,11,5,4,3,2);
DHT11 dht11(7);
SoftwareSerial HC05(A0, A1);
SoftwareSerial agsm(8, 9);

void setup() {
  // put your setup code here, to run once:
    Serial.begin(9600);
    lcd.begin(16,2);
    agsm.begin(9600);
    
    pinMode(A1, OUTPUT);
    digitalWrite(A1, HIGH);
    HC05.begin(9600);

    pinMode(10, OUTPUT);
    pinMode(6, OUTPUT);

}


float h,t;
long data[8];

void loop() {
  // put your main code here, to run repeatedly:
  agsm.listen();
  agsm.write('\r');

  delay(1000);
  
  int num = 0;
  while (agsm.available()) 
  {
    if (agsm.read() == 32)
    {

      int count = 0;
      char str[50] = {0};
      
      while(true)
      { 
        int inByte = agsm.read();

        if(inByte == 44 || !agsm.available()) break;

        str[count] = inByte;
        count++;
        
      }
      
      data[num] = atol(str);
      num++;
    }
  }

  dht11.read(h, t);

  if(t > 40 || data[0] > 100)
  {
    digitalWrite(10, LOW);
    digitalWrite(6, HIGH);
  }
  else
  {
    digitalWrite(10, HIGH);
    digitalWrite(6, LOW);
  }
  
  HC05.listen();
  HC05.print(data[0]);
  HC05.print(",");
  HC05.print(h);
  HC05.print(",");
  HC05.println(t);
  
  
  /*
  if (Serial.available())
  {
    HC05.write(Serial.read());
  }
  if(HC05.available())
  {
    Serial.write(HC05.read());
  }
  */

  
  Serial.print("CO: ");
  Serial.print(data[0]);
  Serial.println("PPB");
  Serial.print(h);
  Serial.print("%\t");
  Serial.print(t);
  Serial.println("C");


  lcd.clear();
  lcd.setCursor(0,0); // LCD 의 시작을 0.0 으로 설정한다.
  lcd.print(" ");
  lcd.print(data[0]);
  lcd.print("PPB");
  lcd.setCursor(0,1); // 줄 바꿈
  lcd.print(" ");
  lcd.print(h);
  lcd.print("%  ");
  lcd.print(t);
  lcd.print("C");


}
