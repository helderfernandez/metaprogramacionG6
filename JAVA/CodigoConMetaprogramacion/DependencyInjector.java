import java.lang.reflect.Constructor;

public class DependencyInjector {
    public static Jugador injectPlayer(String playerType, String nombre, char ficha) {
        try {
            // Obtener la clase del jugador usando reflexión
            Class<?> clazz = Class.forName(playerType);
            
            // Verificar si la clase está marcada con la anotación @InjectPlayer
            if (clazz.isAnnotationPresent(InjectPlayer.class)) {
                // Obtener el constructor que recibe String y char como parámetros
                Constructor<?> constructor = clazz.getConstructor(String.class, char.class);
                
                // Crear una instancia del jugador
                return (Jugador) constructor.newInstance(nombre, ficha);
            } else {
                throw new IllegalArgumentException("La clase " + playerType + " no está marcada con @InjectPlayer");
            }
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
}