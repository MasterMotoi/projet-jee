/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fish.payara.jee;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EntityManager;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;



/**
 *
 * @author tombr
 */
@Entity
@Table(name = "MOT")
@NamedQueries({
    @NamedQuery(name = "Mot.findAll", query = "SELECT m FROM Mot m"),
    @NamedQuery(name = "Mot.findById", query = "SELECT m FROM Mot m WHERE m.id = :id"),
    @NamedQuery(name = "Mot.findByMot", query = "SELECT m FROM Mot m WHERE m.mot = :mot")})
public class Mot implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID")
    private BigDecimal id;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 50)
    @Column(name = "MOT")
    private String mot;

    public Mot() {
    }
    
    public List<Mot> findMot(String motToFind)
    {
        Query query = em.createNamedQuery("Mot.findByMot");
        query.setParameter("mot", motToFind);
        
        return query.getResultList();
    }
    @PersistenceContext(unitName = "my_persistence_unit")
    private EntityManager em;
    public Mot(BigDecimal id) {
        this.id = id;
    }

    public Mot(BigDecimal id, String mot) {
        this.id = id;
        this.mot = mot;
    }

    public BigDecimal getId() {
        return id;
    }

    public void setId(BigDecimal id) {
        this.id = id;
    }

    public String getMot() {
        return mot;
    }

    public void setMot(String mot) {
        this.mot = mot;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Mot)) {
            return false;
        }
        Mot other = (Mot) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "fish.payara.jee.Mot[ id=" + id + " ]";
    }
    
}
