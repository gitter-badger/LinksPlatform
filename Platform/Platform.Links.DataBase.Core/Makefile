CC=gcc
OPTS=-O3 --std=c99 -fPIC -W -Wall -Wextra -pedantic
DEFS=-DLINKS_DLL
core.a	: Link.h Link.c
	${CC} ${OPTS} ${DEFS} -c -o Timestamp.o Timestamp.c
	${CC} ${OPTS} ${DEFS} -c -o Link.o Link.c
	${CC} ${OPTS} ${DEFS} -c -o PersistentMemoryManager.o PersistentMemoryManager.c
	${CC} -shared -o core.so Link.o Timestamp.o PersistentMemoryManager.o
