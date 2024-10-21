# Nom de l'exécutable
TARGET = main.exe

# Fichiers source
SOURCES = SpaceInvaders.cs Armory.cs Spaceship.cs Weapon.cs Player.cs EWeaponType.cs Tardis.cs Dart.cs Rocinante.cs ViperMKII.cs BWings.cs F18.cs IAbility.cs ISpaceship.cs IWeapon.cs IPlayer.cs

# Compilateur
CC = mcs

# Règle par défaut
all: $(TARGET)

# Règle pour créer l'exécutable
$(TARGET): $(SOURCES)
	$(CC) -out:$(TARGET) $(SOURCES)

# Règle pour nettoyer les fichiers générés
clean:
	rm -f $(TARGET)

.PHONY: all clean