using System.Collections;

public interface IDamage  {

    void ApplyDamage(float damage);
    IEnumerator Repulsion();
}
