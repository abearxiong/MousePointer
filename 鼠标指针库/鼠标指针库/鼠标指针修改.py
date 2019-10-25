#!/usr/bin/env python
# coding: utf-8

# ## 获取执行路径

# In[1]:


import os
os.getcwd()
# os.chdir("/media/xiongxiao/code/Abear GitHub/MousePointer/鼠标指针库/鼠标指针库")


# ##  列举文件内容

# ### 函数

# In[2]:


# for root, dirs, files in os.walk(file_dir):
#         print("-----------")
#         print(root)   #os.walk()所在目录
#         print(dirs)   #os.walk()所在目录的所有目录名
#         print(files)   #os.walk()所在目录的所有非目录文件名
#         print("  ")


# ### 执行

# In[3]:


def file_name(file_dir):
    for root, dirs, files in os.walk(file_dir):
#         print("-----------")
#         print(root)   #os.walk()所在目录
#         print(dirs)   #os.walk()所在目录的所有目录名
#         print(files)   #os.walk()所在目录的所有非目录文件名
        for file in files:
            if "右键" in file or "安装" in file:
#                 print(root+"/"+file,"有")
                os.remove(root+"/"+file)
            ### 1. Arrow
#             eqn(file,root, 'arrow', 'Arrow')
            eqn(file,root, 'NOrmal_Select', 'Arrow')
            eqn(file,root, 'NOrmal Select', 'Arrow')
            eqn(file,root, 'normal', 'Arrow')
            eqn(file,root, 'pointer', 'Arrow')
            eqn(file,root, 'cursor', 'Arrow')
            eqn(file,root, '正常', 'Arrow')
            eqn(file,root, '正常选择', 'Arrow')
    
            ### 2. Help
#             eqn(file,root, 'help', 'Help')
            eqn(file,root,'HElp_Select', 'Help')
            eqn(file,root,'HElp Select', 'Help')
            eqn(file,root,'ayuda', 'Help')
            eqn(file,root,'疑问', 'Help')
            eqn(file,root,'帮助选择', 'Help')
    
            ### 3. NWPen
#             eqn(file,root,'NWPen', 'NWPen')
            eqn(file,root,'HANDWRITING','NWPen')
            eqn(file,root,'pen','NWPen')
            eqn(file,root,'手写','NWPen')
            eqn(file,root,'Escritura a Mano','NWPen')
        
            ### 4. UpArrow
#             eqn(file,root, 'UpArrow', 'UpArrow')
            eqn(file,root, 'up', 'UpArrow')
            eqn(file,root, 'arrow up', 'UpArrow')
            eqn(file,root, 'ALternate_Select', 'UpArrow')
            eqn(file,root, 'ALternate Select', 'UpArrow')
            eqn(file,root, 'Alternate', 'UpArrow')
            eqn(file,root, 'Alt', 'UpArrow')
            eqn(file,root, 'Alternative2', 'UpArrow')
            eqn(file,root, '候选', 'UpArrow')
            
            ### 5. NO
#             eqn(file,root, 'no', 'NO')
            eqn(file,root, 'Unavailable', 'NO')
            eqn(file,root, 'unavailiable', 'NO')
            eqn(file,root, 'unavail', 'NO')
            eqn(file,root, '禁止', 'NO')
            eqn(file,root, 'No Disponible', 'NO')
            
            ### 6. SizeAll
#             eqn(file,root, 'SizeAll', 'SizeAll')
            eqn(file,root, 'Move', 'SizeAll')
            eqn(file,root, 'Resize All', 'SizeAll')
            eqn(file,root, 'Movee2', 'SizeAll')
            eqn(file,root, 'Movec', 'SizeAll')
            eqn(file,root, '移动', 'SizeAll')
            
            ### 7. SizeNESW
#             eqn(file,root,'SizeNESW', 'SizeNESW')
            eqn(file,root,'size1', 'SizeNESW')
            eqn(file,root,'NESW', 'SizeNESW')
            eqn(file,root,'Diagonal_Resize_2', 'SizeNESW')
            eqn(file,root,'Diagonal Resize 2', 'SizeNESW')
            eqn(file,root,'Diagonal 2', 'SizeNESW')
            eqn(file,root,'dgn2','SizeNESW')
            eqn(file,root,'diagonal2','SizeNESW')
            eqn(file,root,'diag2','SizeNESW')
            eqn(file,root,'d2res','SizeNESW')
            eqn(file,root,'left','SizeNESW')
            eqn(file,root,'对角线2','SizeNESW')
            eqn(file,root,'沿对角线调整2','SizeNESW')
            eqn(file,root,'lower_right_corner','SizeNESW')
            eqn(file,root,'RZDiagonal2','SizeNESW')
            eqn(file,root,'RESIZE RIGHT','SizeNESW')
            eqn(file,root,'RESIZE DIAGONAL-RIGHT','SizeNESW')
            
            ### 8. SizeNWSE
#             eqn(file,root,'SizeNWSE', 'SizeNWSE')
            eqn(file,root,'size2', 'SizeNWSE')
            eqn(file,root,'nwse', 'SizeNWSE')
            eqn(file,root,'Diagonal_Resize_1', 'SizeNWSE')
            eqn(file,root,'Diagonal Resize 1', 'SizeNWSE')
            eqn(file,root,'Diagonal 1', 'SizeNWSE')
            eqn(file,root,'diagonal1', 'SizeNWSE')
            eqn(file,root,'dgn1', 'SizeNWSE')
            eqn(file,root,'diag1', 'SizeNWSE')
            eqn(file,root,'d1res', 'SizeNWSE')
            eqn(file,root,'right', 'SizeNWSE')
            eqn(file,root,'REsize right', 'SizeNWSE')
            eqn(file,root,'对角线1', 'SizeNWSE')
            eqn(file,root,'沿对角线调整1', 'SizeNWSE')
            eqn(file,root,'RZDiagonal1', 'SizeNWSE')
            eqn(file,root,'top_left_corner', 'SizeNWSE')
            eqn(file,root,'RESIZE DIAGONAL-LEFT', 'SizeNWSE')
            
            ### 9. SizeWE
#             eqn(file,root,'SizeWE', 'SizeWE')
            eqn(file,root,'size3', 'SizeWE')
            eqn(file,root,'EW', 'SizeWE')
            eqn(file,root,'Horizontal_Resize','SizeWE')
            eqn(file,root,'Horizontal Resize','SizeWE') 
            eqn(file,root,'Horizont','SizeWE') 
            eqn(file,root,'Horizontal','SizeWE') 
            eqn(file,root,'horz','SizeWE')
            eqn(file,root,'hres','SizeWE')
            eqn(file,root,'水平','SizeWE')
            eqn(file,root,'水平调整','SizeWE')
            eqn(file,root,'RZHorizontal','SizeWE')
            eqn(file,root,'transverse','SizeWE')
            eqn(file,root,'RESIZE HORIZONTAL','SizeWE')
            
            ### 10. SizeNS
#             eqn(file,root,'SizeNS', 'SizeNS')
            eqn(file,root,'size4', 'SizeNS')
            eqn(file,root,'ns', 'SizeNS')
            eqn(file,root,'Vertical_Resize','SizeNS')
            eqn(file,root,'Vertical Resize','SizeNS')
            eqn(file,root,'Size Vert','SizeNS')
            eqn(file,root,'Vertical','SizeNS')
            eqn(file,root,'Vertical1','SizeNS')
            eqn(file,root,'vert','SizeNS')
            eqn(file,root,'vres','SizeNS')
            eqn(file,root,'vertic','SizeNS')
            eqn(file,root,'Size Horz','SizeNS')
            eqn(file,root,'垂直','SizeNS')
            eqn(file,root,'垂直调整','SizeNS')
            eqn(file,root,'RZVertical','SizeNS')
            eqn(file,root,'PORTRAIT','SizeNS')
            eqn(file,root,'Resize VERTICAL','SizeNS')
        
            ### 11. Wait
#             eqn(file,root, 'wait', 'Wait')
            eqn(file,root, 'BUSY', 'Wait')
            eqn(file,root, 'Ocupado', 'Wait')
            eqn(file,root, '忙碌', 'Wait')
            eqn(file,root, '忙', 'Wait')
            
            ### 12. AppStarting
#             eqn(file,root,'appstarting', 'Appstarting')
            eqn(file,root,'work_in_background', 'Appstarting')
            eqn(file,root,'work in background', 'Appstarting')
            eqn(file,root,'Working In Background', 'Appstarting')
            eqn(file,root,'work', 'Appstarting')
            eqn(file,root,'working', 'Appstarting')
            eqn(file,root,'trabajando en segundo plano', 'Appstarting')
            eqn(file,root,'后台', 'Appstarting')
            eqn(file,root,'后台运行', 'Appstarting')
            eqn(file,root,'backgrounder', 'Appstarting')
            
            ### 13. IBeam
#             eqn(file,root, 'IBeam', 'IBeam')
            eqn(file,root, 'beam', 'IBeam')
            eqn(file,root,'Text_Select','IBeam')
            eqn(file,root,'Text Select','IBeam')
            eqn(file,root,'Text','IBeam')
            eqn(file,root,'Texto','IBeam')
            eqn(file,root,'select','IBeam')
            eqn(file,root,'文本','IBeam')
            eqn(file,root,'文本选择','IBeam')
            
            ### 14. Crosshair
#             eqn(file,root,'Crosshair', 'Crosshair')
            eqn(file,root,'Cross', 'Crosshair')
            eqn(file,root,'Precision_Select', 'Crosshair')
            eqn(file,root,'Precision Select', 'Crosshair')
            eqn(file,root,'Precision', 'Crosshair')
            eqn(file,root,'定位', 'Crosshair')
            eqn(file,root,'精确选择', 'Crosshair')
            
            ### 15. Hand
#             eqn(file,root,'Hand', 'Hand')          
            eqn(file,root,'link', 'Hand')          
            eqn(file,root,'Link_Select', 'Hand')
            eqn(file,root,'Link Select', 'Hand')
            eqn(file,root,'链接', 'Hand')
            eqn(file,root,'链接选择', 'Hand')
            
            ### 16. Pin
#             eqn(file,root,'Pin', 'Pin')
            eqn(file,root,'place', 'Pin')
            eqn(file,root,'LOcation select', 'Pin')
            eqn(file,root,'position', 'Pin')
            
            ### 17. Person
#             eqn(file,root,'Person','Person')
            eqn(file,root,'account','Person')
            eqn(file,root,'person select','Person')
            
#         print(" ")
def eqn(file,root,name,cname):
    if file.upper() == name.upper() + '.CUR':
        print(root+"/"+file)
        os.rename(root+"/"+file, root+"/"+cname+'.cur')
    elif file.upper() == name.upper() + '.ANI':
        print(root+"/"+file)
        os.rename(root+"/"+file, root+"/"+cname+'.ani')
root_path = "/media/xiongxiao/code/Abear GitHub/MousePointer/鼠标指针库/鼠标指针库"
file_name(root_path)


# ### 生成auto_setup

# In[5]:


head ="""
[DefaultInstall]
CopyFiles = Scheme.Cur
AddReg    = Scheme.Reg,Wreg


[DestinationDirs]
Scheme.Cur = 10,"%CUR_DIR%"


[Scheme.Reg]
HKCU,"Control Panel\Cursors\Schemes","%SCHEME_NAME%",,"%10%\%CUR_DIR%\%pointer%,%10%\%CUR_DIR%\%help%,%10%\%CUR_DIR%\%work%,%10%\%CUR_DIR%\%busy%,%10%\%CUR_DIR%\%Cross%,%10%\%CUR_DIR%\%Text%,%10%\%CUR_DIR%\%Hand%,%10%\%CUR_DIR%\%Unavailiable%,%10%\%CUR_DIR%\%Vert%,%10%\%CUR_DIR%\%Horz%,%10%\%CUR_DIR%\%Dgn1%,%10%\%CUR_DIR%\%Dgn2%,%10%\%CUR_DIR%\%move%,%10%\%CUR_DIR%\%alternate%,%10%\%CUR_DIR%\%link%"


[Wreg]
HKCU,"Control Panel\Cursors",,0x00020000,"%SCHEME_NAME%"
HKCU,"Control Panel\Cursors",AppStarting,0x00020000,"%10%\%CUR_DIR%\%work%"
HKCU,"Control Panel\Cursors",Arrow,0x00020000,"%10%\%CUR_DIR%\%pointer%"
HKCU,"Control Panel\Cursors",Crosshair,0x00020000,"%10%\%CUR_DIR%\%Cross%"
HKCU,"Control Panel\Cursors",Hand,0x00020000,"%10%\%CUR_DIR%\%link%"
HKCU,"Control Panel\Cursors",Help,0x00020000,"%10%\%CUR_DIR%\%Help%"
HKCU,"Control Panel\Cursors",IBeam,0x00020000,"%10%\%CUR_DIR%\%Text%"
HKCU,"Control Panel\Cursors",No,0x00020000,"%10%\%CUR_DIR%\%Unavailiable%"
HKCU,"Control Panel\Cursors",NWPen,0x00020000,"%10%\%CUR_DIR%\%Hand%"
HKCU,"Control Panel\Cursors",SizeAll,0x00020000,"%10%\%CUR_DIR%\%move%"
HKCU,"Control Panel\Cursors",SizeNESW,0x00020000,"%10%\%CUR_DIR%\%Dgn2%"
HKCU,"Control Panel\Cursors",SizeNS,0x00020000,"%10%\%CUR_DIR%\%Vert%"
HKCU,"Control Panel\Cursors",SizeNWSE,0x00020000,"%10%\%CUR_DIR%\%Dgn1%"
HKCU,"Control Panel\Cursors",SizeWE,0x00020000,"%10%\%CUR_DIR%\%Horz%"
HKCU,"Control Panel\Cursors",UpArrow,0x00020000,"%10%\%CUR_DIR%\%alternate%"
HKCU,"Control Panel\Cursors",Wait,0x00020000,"%10%\%CUR_DIR%\%busy%"
HKCU,"Control Panel\Cursors",Pin,0x00020000,"%10%\%CUR_DIR%\%pin%"
HKCU,"Control Panel\Cursors",Person,0x00020000,"%10%\%CUR_DIR%\%person%"
HKLM,"SOFTWARE\Microsoft\Windows\CurrentVersion\Runonce\Setup\","",,"rundll32.exe shell32.dll,Control_RunDLL main.cpl @0,1"


[Scheme.Cur]
"Arrow.cur"
"Help.cur"
"AppStarting.cur"
"Wait.cur"
"Crosshair.cur"
"IBeam.cur"
"NWPen.cur"
"NO.cur"
"SizeNS.cur"
"SizeNWSE.cur"
"SizeNESW.cur"
"SizeWE.cur"
"SizeAll.cur"
"UpArrow.cur"
"Hand.cur"
"Pin.cur"
"Person.cur"

[Strings]
"""
tail ="""
pointer		= "Arrow.cur"
help		= "Help.cur"
work		= "AppStarting.cur"
busy		= "Wait.cur"
cross		= "Crosshair.cur"
text		= "IBeam.cur"
hand		= "NWPen.cur"
unavailiable	= "NO.cur"
vert		= "SizeNS.cur"
horz		= "SizeWE.cur"
dgn1		= "SizeNWSE.cur"
dgn2		= "SizeNESW.cur"
move		= "SizeAll.cur"
alternate		= "UpArrow.cur"
link		= "Hand.cur"
pin		= "Pin.cur"
person		= "Person.cur"
"""
print(head,tail)
def write_file(root,name):
    with open(root+"/"+name+"/"+"AutoSetup.inf",'w+') as f:
        f.write(head)
        f.write('CUR_DIR ="Cursors\\'+ name +'"\n')
        f.write('SCHEME_NAME ="'+ name +'"')
        f.write(tail)
        f.close()
# write_file(root_path,"内容")
def file_name(file_dir):
    for root, dirs, files in os.walk(file_dir):
#         print("-----------")
#         print(root)   #os.walk()所在目录
#         print(dirs)   #os.walk()所在目录的所有目录名
#         print(files)   #os.walk()所在目录的所有非目录文件名
        for wdir in dirs:
#             print(wdir)
            write_file(root,wdir)
#         print(" ")

file_name(root_path + "/致美化")


# In[ ]:




