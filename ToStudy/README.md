# Unity3D

    AR Foundation을 활용하여 AR을 실행시기키 위해서 지켜야할 환경설정


- Build setting 에서 Android환경으로 Switch Platform을 한다.  
- Package Manager의 Unity Registry로 설정하고 AR을 검색한다.   
    ( AR Foundation, ARCore(android), ARKit(ios)를 install )
- Project setting에서 XR Plugin에서 android,ios 환경에서 각각의 package를 활성화한다.
- Player setting에서 Minimum API level을 24로 맞춰주고 scripting backend를 IL2CPP, TargetArchitectures에서 ARM64로 체크해준다.
------

## 프로젝트를 진행하기 위한 기능 계획

1. 평면, pointer 인식하기 ✔
2. 얼굴 인식하기 ✔
3. 공날리기 ✔
4. 벽에 공만들기
5. 사진인식하여 객체 띄우기
6. 3D펜 구현하기
