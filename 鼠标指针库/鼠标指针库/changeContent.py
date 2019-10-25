import os
print("原始的目录",os.getcwd())

os.chdir("F:\Abear GitHub\MousePointer\鼠标指针库\鼠标指针库")
print("开始的目录",os.getcwd())

def dirlist(path, allfile):
    filelist=os.listdir(path)
    for filename  in  filelist:
        filepath=os.path.join(path,filename)
        if os.path.isdir(filepath):
            dirlist(filepath,allfile)
        else:
            allfile.append(filepath)
            return allfile

print(dirlist("F:\Abear GitHub\MousePointer\鼠标指针库\鼠标指针库",[]))

# from glob import glob
# from os import path
# def dirlist(parent, allfile):
#   pattern = path.join(parent, '*', '*.wav')
#   return glob(pattern)
