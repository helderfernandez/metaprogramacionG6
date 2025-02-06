import java.lang.reflect.Proxy;

public class JugadorProxy {
    public static Jugador createProxy(Jugador target) {
        return (Jugador) Proxy.newProxyInstance(
            Jugador.class.getClassLoader(), // Cargador de clases
            new Class<?>[] { Jugador.class }, // Interfaces que implementa el proxy
            new JugadorInvocationHandler(target) // Manejador de invocación
        );
    }
}