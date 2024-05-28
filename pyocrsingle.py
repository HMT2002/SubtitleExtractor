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

#We then Construct an Argument Parser
ap=argparse.ArgumentParser()
ap.add_argument("-i","--image",
                required=True,
                help="Path to the image folder")
ap.add_argument("-p","--pre_processor",
                default="thresh", 
                help="the preprocessor usage")
args=vars(ap.parse_args())
single_image=args["image"]

re = open(single_image+"_quicktest.txt", "w")
re.write("")
re.close()
# init easyocr
# reader = easyocr.Reader(['vi']) # this needs to run only once to load the model into memory
reader = easyocr.Reader(['vi','en'])
result = reader.readtext(single_image)
for line in result:
  sub=""
  if len(line[0])>1:
    sub+=line[1]+"\n"
  print(str(sub).encode("utf-8"), flush=True)
  re = open(single_image+"_quicktest.txt", "a+", encoding="utf-8")
  re.write(str(sub))
  re.close()