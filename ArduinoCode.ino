/* Get tilt angles on X and Y, and rotation angle on Z
 * Angles are given in degrees
 * 
 * License: MIT
 */

#include "Wire.h"
#include <MPU6050_light.h>

MPU6050 mpu(Wire);
unsigned long timer = 0;

void setup() {
  Serial.begin(9600);
  Wire.begin();
  
  byte status = mpu.begin();
  //Serial.print(F("MPU6050 status: "));
  //Serial.println(status);
  while(status!=0){ } // stop everything if could not connect to MPU6050
  
  //Serial.println(F("Calculating offsets, do not move MPU6050"));
  delay(1000);
  // mpu.upsideDownMounting = true; // uncomment this line if the MPU6050 is mounted upside-down
  mpu.calcOffsets(); // gyro and accelero
  //Serial.println("Done!\n");
}
// speedx = 0;
void loop() {
  mpu.update();
  
  if((millis()-timer)>100){ // print data every 10ms
    //speedx = analogRead(A0);
	//Serial.print("X : ");

	Serial.print(map(mpu.getAngleX(), -10,5,-1,1));
  Serial.print(",");
	//Serial.print("\tY : ");
	Serial.print(map(mpu.getAngleY(), -20,10,-1,1));

  Serial.print(",");
	//Serial.print("\tZ : ");
	Serial.println(map(mpu.getAngleZ(), -20,10,-1,1));

  //Serial.print(",");
//  Serial.print(mpu.getAngleX());
//  Serial.print(",");
//  Serial.print(mpu.getAngleY());
//  Serial.print(",");
//  Serial.print(mpu.getAngleZ());
//  Serial.print(",");
  //Serial.println(map(speedx,0,533,-10,10));
	timer = millis();  
  }
}
