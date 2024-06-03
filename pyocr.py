import cv2
import os,argparse
import pytesseract
import pathlib
from PIL import Image
import easyocr
import math
import io
import sys
import time
def format_a_line(text,timeFrom,timeTo,index):
  milisecTimeFrom=timeFrom%1000
  secTimeFrom=timeFrom//1000
  hourTimeFrom=int(round(secTimeFrom//(60*60)))
  secTimeFrom=secTimeFrom-(hourTimeFrom*(60*60))
  minuteTimeFrom=int(round(secTimeFrom//(60)))
  secTimeFrom = secTimeFrom- (minuteTimeFrom *(60))
  milisecTimeTo=timeTo%1000
  secTimeTo=timeTo//1000
  hourTimeTo=int(round(secTimeTo//(60*60)))
  secTimeTo=secTimeTo-(hourTimeTo*(60*60))
  minuteTimeTo=int(round(secTimeTo//(60)))
  secTimeTo = secTimeTo- (minuteTimeTo *(60))
  if hourTimeFrom<10:
     hourTimeFrom="0"+str(hourTimeFrom)
  if hourTimeTo<10:
     hourTimeTo="0"+str(hourTimeTo)
  if minuteTimeFrom<10:
     minuteTimeFrom="0"+str(minuteTimeFrom)
  if minuteTimeTo<10:
     minuteTimeTo="0"+str(minuteTimeTo)
  if secTimeFrom<10:
     secTimeFrom="0"+str(secTimeFrom)
  if secTimeTo<10:
     secTimeTo="0"+str(secTimeTo)
  if milisecTimeFrom<100:
     if milisecTimeFrom<10:
       milisecTimeFrom="00"+str(milisecTimeFrom)
     else:
       milisecTimeFrom="0"+str(milisecTimeFrom)

  if milisecTimeTo<100:
     if milisecTimeTo<10:
       milisecTimeTo="00"+str(milisecTimeTo)
     else:
       milisecTimeTo="0"+str(milisecTimeTo)


  writeText=str(index)+"\n"+str(hourTimeFrom)+":"+str(minuteTimeFrom)+":"+str(secTimeFrom)+","+str(milisecTimeFrom)+" --> "+str(hourTimeTo)+":"+str(minuteTimeTo)+":"+str(secTimeTo)+","+str(milisecTimeTo)+"\n "+text+"\n"+"\n"
  print(writeText.encode("utf-8"), flush=True)
  return writeText

#We then Construct an Argument Parser
ap=argparse.ArgumentParser()
ap.add_argument("-i","--image",
                required=True,
                help="Path to the image folder")
ap.add_argument("-f","--folder",
                required=True,
                help="Path to the folder")
ap.add_argument("-sub","--subname",
                required=True,
                help="Subtitle file name")
ap.add_argument("-p","--pre_processor",
                default="thresh", 
                help="the preprocessor usage")
args=vars(ap.parse_args())
single_image=args["image"]
folder_image=args["folder"]
sub_name=args["subname"]

# init easyocr
reader = easyocr.Reader(['vi']) # this needs to run only once to load the model into memory
# reader = easyocr.Reader(['vi','en'])
step=0
index=1
#read files in folder
path = str(pathlib.Path().resolve())+'\\'+folder_image
# print(path)
dir_list = os.listdir(path)
# print( "Files and directories in '", path, "' :")
# prints all files
re = open(sub_name+".srt", "w")
re.write("")
re.close()
for file in dir_list:
  #We then read the image with text
  # images=cv2.imread(path+'\\'+file)
  # #convert to grayscale image
  # gray=cv2.cvtColor(images, cv2.COLOR_BGR2GRAY)
  # #checking whether thresh or blur
  # if args["pre_processor"]=="thresh":
  #     cv2.threshold(gray, 0,255,cv2.THRESH_BINARY| cv2.THRESH_OTSU)[1]
  # if args["pre_processor"]=="blur":
  #     cv2.medianBlur(gray, 3) 
  #memory usage with image i.e. adding image to memory
  # filename = "{}.jpg".format(os.getpid())
  # cv2.imwrite(filename, gray)
  # os.remove(filename)
  # text = pytesseract.image_to_string(Image.open(filename),lang='vie')
  result = reader.readtext(folder_image+"/"+file)
   # result.reverse()
  for line in result:
      sub=""

      if len(result[0])>1:
         sub+=line[1]+"\\N"

      fullsub=format_a_line(sub,step,step+500,index)
      with open(sub_name+".srt", 'a+', encoding="utf-8") as f: #this use to append
         #with open("sub.srt", 'w', encoding="utf-8") as f: #this use to overwrite
         f.write(fullsub)
         index=index+1

  step=step+500

# show the output images
# cv2.imshow("Image Input", images)
# cv2.imshow("Output In Grayscale", gray)
# cv2.waitKey(0)
#input("Press Enter to continue...")
